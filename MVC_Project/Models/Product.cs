using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC_Project.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]

        [DisplayName("Product Name")]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public float Price { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
