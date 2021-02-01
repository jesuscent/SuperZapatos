using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSuperZapatos.Models
{
    public class Articles
    {
        [Key]
        public int ArticleID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Display(Name = "Total in Shelf")]
        [DefaultValue(0)]
        public int Total_in_shelf { get; set; }

        [DefaultValue(0)]
        [Display(Name = "Total in Vault")]
        public int Total_in_vault { get; set; }

        public int StoreID { get; set; }
        [ForeignKey("StoreID")]
        public virtual Stores Stores { get; set; }
    }
}