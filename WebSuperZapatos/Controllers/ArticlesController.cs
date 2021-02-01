using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebSuperZapatos.App_Start;
using WebSuperZapatos.Models;

namespace WebSuperZapatos.Controllers
{
    public class ArticlesController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Articles

        public async Task<ActionResult> Index()
        {
            var articles = await _context.Articles.Include(x => x.Stores).ToListAsync();

            return View(articles);
        }

        public ActionResult Create()
        {
            ViewBag.StoreID = new SelectList(_context.Stores, "StoreID", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( Articles articles)
        {
            if (ModelState.IsValid)
            {
                _context.Articles.Add(articles);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StoreID = new SelectList(_context.Stores, "StoreID", "Name", articles.StoreID);
            return View(articles);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articles articles = await _context.Articles.FindAsync(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoreID = new SelectList(_context.Stores, "StoreID", "Name", articles.StoreID);
            return View(articles);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( Articles articles)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(articles).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StoreID = new SelectList(_context.Stores, "StoreID", "Name", articles.StoreID);
            return View(articles);
        }

     

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articles articles = await _context.Articles.FindAsync(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View(articles);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int? id)
        {
            Articles articles = await _context.Articles.FindAsync(id);
            _context.Articles.Remove(articles);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}