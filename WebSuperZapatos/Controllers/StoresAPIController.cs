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
    public class StoresAPIController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        private ResponseAPI response = new ResponseAPI();
        private ResponseStores responseStores = new ResponseStores();
        private ErrorResponse reponseError = new ErrorResponse();
        public HttpResponseMessage GetStores()
        {
            try
            {
                var stores = _context.Stores.ToList();
                var total = stores.Count();
                List<Stores> lsStores = new List<Stores>();               
                lsStores = stores;

                responseStores = response.responseStoresSuccess(lsStores, total);
                return Request.CreateResponse(HttpStatusCode.OK, responseStores);
            }
            catch (Exception)
            {

                throw;
            }

        }

        
        [ResponseType(typeof(Stores))]
        public HttpResponseMessage GetStores(int id)
        {          

            try
            {
                var stores = _context.Stores.FindAsync(id);
                var total = _context.Stores.Count();
                if (stores == null)
                {
                    reponseError = response.responseError(HttpStatusCode.NotFound);
                    return Request.CreateResponse(HttpStatusCode.NotFound, reponseError, Configuration.Formatters.JsonFormatter);
                }

                responseStores = response.responseStoresSuccess(stores, total);
                return Request.CreateResponse(HttpStatusCode.OK, responseStores, Configuration.Formatters.JsonFormatter);
            }
            catch (Exception ex)
            {
                reponseError = response.responseError(HttpStatusCode.BadRequest);
                return Request.CreateResponse(HttpStatusCode.BadRequest, reponseError, Configuration.Formatters.JsonFormatter);
            }
        }

       
    }
}