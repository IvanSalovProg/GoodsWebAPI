using System.ComponentModel.DataAnnotations;

namespace Goods.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int VendorCode { get; set; }

        public int Price { get; set; }

        public string NameGoods { get; set; }

        public string ProductCategory { get; set; }
    }
}
