using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
  [Authorize(Roles = "Admin")]
      public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index([FromQuery] ProductRequestParameters p)
        {
            ViewData["Title"] = "Products";

           var  products = _manager.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination(){
                CurrentPage = p.PageNumber, 
                ItemsPerPage = p.PageSize, 
                TotalItems = _manager.ProductService.GetAllProduct(false).Count()
            };
            return View(new ProductListViewModel(){
                Products = products,
                Pagination = pagination
            });
        }

        public IActionResult Create()
        {
            TempData["info"] = "Lütfen formu doldurunuz.";
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file operations
                string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                productDto.ImageUrl = String.Concat("/images/", file.FileName);

                _manager.ProductService.CreateProduct(productDto);
                TempData["success"] = $"{productDto.ProductName} başarıyla eklendi.";
                return RedirectToAction("Index");
            }
            return View();

        }
        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryId", "CategoryName", "1");
        }

   

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductService.GetProductForUpdate(id, false);
            ViewData["Title"] = model?.ProductName;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file operations
                string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                productDto.ImageUrl = String.Concat("/images/", file.FileName);

                _manager.ProductService.UpdateOneProduct(productDto);
                TempData["success"] = $"{productDto.ProductName} başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            TempData["danger"] = "Ürün başarıyla kaldırıldı.";
            return RedirectToAction("Index");
        }

    }
}