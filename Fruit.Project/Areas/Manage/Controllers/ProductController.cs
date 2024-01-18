using Fruit.Project.Areas.Manage.ViewModels.ProductVMs;
using Fruit.Project.DAL;
using Fruit.Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace Fruit.Project.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _db.Products.ToListAsync();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            Product product = new Product()
            {
                Title = vm.Title,
                SubTitle = vm.SubTitle
            };
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            Product product = await _db.Products.FindAsync(id);
            ProductUpdateVM updated = new ProductUpdateVM()
            {
                Id = product.Id,
                Title=product.Title,
                SubTitle=product.SubTitle

            };
            return View(updated );
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if(vm.Id<= 0) { throw new Exception("Id isn't Zero or negative."); }
            var product = await _db.Products.FirstOrDefaultAsync(x=>x.Id==vm.Id);
            if(product == null) { throw new Exception("Product isn't null"); }
            product.Title = vm.Title;
            product.SubTitle = vm.SubTitle;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            Product product =await  _db.Products.FindAsync(id);
             _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");    
        }

    }
}
