using Microsoft.AspNetCore.Mvc;
using Product.Data.Models.Domain;
using Product.Data.Repository;

namespace Assignmnet.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task <IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Products product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                product.CreatedAt = DateTime.UtcNow;
                bool addProductrsult = await _productRepo.AddAsync(product);
                if (addProductrsult)
                {
                    TempData["msg"] = "Successfully added";
                }
                else
                {
                    TempData["msg"] = "Could not added";
                }

            }

            catch
            {
                TempData["msg"] = "Could not added";
            }

            return RedirectToAction(nameof(Add));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Products product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                bool updateresult = await _productRepo.UpdateAsync(product);
                if (updateresult)
                {
                    TempData["msg"] = "Successfully updated";
                }
                else
                {
                    TempData["msg"] = "Could not updated";
                }
            }

            catch(Exception ex)
            {
                TempData["msg"] = "Could not updated";
            }
            return View(product);
        }

        public async Task<IActionResult> GetById(int id)
        {
            return View();
        }

        public async Task<IActionResult> DisplayAll()
        {
            var product = await _productRepo.GetAllAsync();
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deleteresult = await _productRepo.DeleteAsync(id);
            return RedirectToAction(nameof(DisplayAll));
        }
    }
}
