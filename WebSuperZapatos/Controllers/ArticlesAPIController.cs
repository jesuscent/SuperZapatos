using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebSuperZapatos.App_Start;
using WebSuperZapatos.Models;

namespace WebSuperZapatos.Controllers
{
    [Authorize]
    public class ArticlesAPIController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        private ResponseAPI response = new ResponseAPI();
        private ResponseArticles responseArticles = new ResponseArticles();
        private ErrorResponse reponseError = new ErrorResponse();

        public HttpResponseMessage GetArticles()
        {
            try
            {
                var articles = _context.Articles.ToList();
                var total = articles.Count();
                List<Articles> lsArticles = new List<Articles>();
                lsArticles = articles;                

                responseArticles = response.responseArticleSuccess(lsArticles, total);
                return Request.CreateResponse(HttpStatusCode.OK, responseArticles);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

      
        [HttpGet]
        public HttpResponseMessage Stores(int id)
        {
            try
            {
                var articles = _context.Articles.Where(x => x.StoreID == id).ToList();
                var total = articles.Count();
                List<Articles> lsArticles = new List<Articles>();
                lsArticles = articles;

                if (lsArticles == null)
                {
                    reponseError = response.responseError(HttpStatusCode.NotFound);
                    return Request.CreateResponse(HttpStatusCode.NotFound, reponseError, Configuration.Formatters.JsonFormatter);
                } 

                responseArticles = response.responseArticleSuccess(articles, total);
                return Request.CreateResponse(HttpStatusCode.OK, responseArticles, Configuration.Formatters.JsonFormatter);
            }
            catch (Exception ex)
            {
                reponseError = response.responseError(HttpStatusCode.BadRequest);
                return Request.CreateResponse(HttpStatusCode.BadRequest, reponseError, Configuration.Formatters.JsonFormatter);
            }



        }

    }
}