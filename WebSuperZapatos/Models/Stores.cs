using System.ComponentModel.DataAnnotations;

namespace WebSuperZapatos.Models
{
    public class Stores
    {
        [Key]
        public int StoreID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string address { get; set; }
    }
}