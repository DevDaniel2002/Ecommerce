using BackEndEcommerce.Models;
using BackEndEcommerce.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController<Product>
    {
        public ProductsController(eCommerceContext _context, IRepository<Product> _repository) : base(_context, _repository)
        {
        }
    }
}
