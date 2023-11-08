using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Goods.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }

        public Group? Group { get; set; }

        public int VendorCode { get; set; }

        public int Price { get; set; }

        public string NameGoods { get; set; }

        public string ProductCategory { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
