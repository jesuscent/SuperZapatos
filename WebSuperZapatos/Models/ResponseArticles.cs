using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSuperZapatos.Models
{
    public class ResponseArticles
    {
        public object articles { get; set; }
        public bool success { get; set; }
        public int total_elements { get; set; }
    }
}