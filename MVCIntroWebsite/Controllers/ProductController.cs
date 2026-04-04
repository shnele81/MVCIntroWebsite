using Microsoft.AspNetCore.Mvc;
using MVCIntroWebsite.Data;

namespace MVCIntroWebsite.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    // GET
    public IActionResult Index()
    {
        var products = _productRepository.GetAllProducts();
        return View(products);
    }

    public IActionResult ViewProduct(int id)
    {
        var product = _productRepository.GetProductById(id);
        return View(product);
    }
}