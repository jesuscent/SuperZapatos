using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSuperZapatos.Models
{
    public class Stores
    {
        [Key]
        public int StoreID { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Dirección")]
        public string address { get; set; }
    }
}