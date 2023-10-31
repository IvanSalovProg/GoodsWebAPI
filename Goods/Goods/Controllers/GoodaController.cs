using Goods.Models;
using Microsoft.AspNetCore.Mvc;

namespace Goods.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoodaController : Controller
    {
        [HttpGet]
        public Product Get()
        {
            return new Product { NameGoods = "Носки шерстяные", ProductCategory = "Вязанные изделия", VendorCode = 555243, Price = 50 };
        }
    }
}
