using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignmnet.Models;
using Product.Data.Repository;

namespace Assignmnet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductRepository _productRepo;

    public HomeController(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productRepo.GetAllProductsAsync();
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
