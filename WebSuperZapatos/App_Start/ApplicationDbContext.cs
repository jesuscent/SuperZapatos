using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebSuperZapatos.Models;

namespace WebSuperZapatos.App_Start
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext() : base("CentenoConnection") { }

        public DbSet<Stores> Stores { get; set; }
        public DbSet<Articles> Articles { get; set; }
    }
}
