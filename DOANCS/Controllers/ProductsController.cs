using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOANCS.Models;
using DOANCS.Data;

namespace DOANCS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ApplicationDbContext context, ILogger<ProductsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            // Load categories, colors, and sizes to pass to the view
            ViewData["Categories"] = _context.Categories.ToList();
            ViewData["Colors"] = _context.Colors.ToList();
            ViewData["Sizes"] = _context.Sizes.ToList();
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product model)
        {
            if (ModelState.IsValid)
            {
                
                    var product = new Product
                    {
                        Name = model.Name,
                        Description = model.Description,
                        CategoryId = model.CategoryId,
                        ProductDetails = new List<ProductDetail>()
                    };

                    // Tạo và thêm các chi tiết sản phẩm vào danh sách ProductDetails
                    foreach (var pd in model.ProductDetails)
                    {
                        var productDetail = new ProductDetail
                        {
                            
                            ColorId = pd.ColorId,
                            SizeId = pd.SizeId,
                            Price = pd.Price,
                            Quantity = pd.Quantity
                        };
                        product.ProductDetails.Add(productDetail);
                    }

                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
               
            }

            // If we got this far, something failed; reload the necessary data and return the view
            ViewData["Categories"] = _context.Categories.ToList();
            ViewData["Colors"] = _context.Colors.ToList();
            ViewData["Sizes"] = _context.Sizes.ToList();
            return View(model);
        }


        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Include(p => p.ProductDetails).ToListAsync();
            return View(products);
        }
    }
}