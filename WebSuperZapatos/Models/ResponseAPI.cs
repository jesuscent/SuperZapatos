using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebSuperZapatos.Models
{
    public class ResponseAPI
    {
        public ResponseStores responseStoresSuccess(object stores, int total)
        {
            ResponseStores objSuccess = new ResponseStores();
            objSuccess.success = true;
            objSuccess.stores = stores;
            objSuccess.total_elements = total;

            return objSuccess;
        }
        public ResponseArticles responseArticleSuccess(object articles, int total)
        {
            ResponseArticles objSuccess = new ResponseArticles();
            objSuccess.success = true;
            objSuccess.articles = articles;
            objSuccess.total_elements = total;

            return objSuccess;
        }      

        public ErrorResponse responseError(HttpStatusCode error_code)
        {
            ErrorResponse objError = new ErrorResponse();
            objError.error_msg = messageError(error_code);
            objError.error_code = error_code;
            objError.success = false;

            return objError;
        }

        public string messageError(HttpStatusCode error_code)
        {
            ErrorResponse objError = new ErrorResponse();
            int code = Convert.ToInt32(error_code);
            string message = "";

            switch (code)
            {
                case 400:
                    message = ErrorResponse.error400;
                    break;
                case 401:
                    message = ErrorResponse.error401;
                    break;
                case 404:
                    message = ErrorResponse.error404;
                    break;
                case 500:
                    message = ErrorResponse.error500;
                    break;
                default:
                    message = "Fault occurred";
                    break;
            }

            return message;
        }
    }
}