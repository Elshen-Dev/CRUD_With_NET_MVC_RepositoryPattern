using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUDWithRepositoryPattern.Core
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Product Name")]   
        public string ProductName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
