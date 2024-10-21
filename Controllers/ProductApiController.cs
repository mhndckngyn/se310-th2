using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using se310_th2.Context;
using se310_th2.Models;
using se310_th2.Models.ProductModel;

namespace se310_th2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private MyDbContext db = new MyDbContext();

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            var products = 
                (from p in db.TDanhMucSps
                select new Product
                {
                    MaSp = p.MaSp,
                    TenSp = p.TenSp,
                    MaLoai = p.MaLoai,
                    AnhDaiDien = p.AnhDaiDien,
                    GiaNhoNhat = p.GiaNhoNhat
                });

            return products.ToList();
        }

        [HttpGet("{maLoai}")]
        public IEnumerable<Product> GetProductsByCategory(string maLoai)
        {
            var products = 
                from p in db.TDanhMucSps
                where p.MaLoai == maLoai
                select new Product
                {
                    MaSp = p.MaSp,
                    TenSp = p.TenSp,
                    MaLoai = p.MaLoai,
                    AnhDaiDien = p.AnhDaiDien,
                    GiaNhoNhat = p.GiaNhoNhat
                };

            return products.ToList();
        }
    }
}
