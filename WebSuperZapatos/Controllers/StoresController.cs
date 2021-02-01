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
    public class StoresController : Controller
    {
        private  ApplicationDbContext _context = new ApplicationDbContext();
        
       
        // GET: Stores
        public async Task<ActionResult> Index()
        {
            var List = await _context.Stores.ToListAsync();

            return View(List);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Stores stores)
        {
            if (ModelState.IsValid)
            {
                _context.Stores.Add(stores);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(stores);
        }
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stores stores = await _context.Stores.FindAsync(id);
            if (stores == null)
            {
                return HttpNotFound();
            }
            return View(stores);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Stores stores)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(stores).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(stores);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int? id)
        {
            Stores stores = await _context.Stores.FindAsync(id);
            _context.Stores.Remove(stores);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
           
        }

      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}