using Microsoft.AspNetCore.Mvc;
using MVCIntroWebsite.Data;
using MVCIntroWebsite.Models;

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

    public IActionResult UpdateProduct(int id)
    {
        Product prod = _productRepository.GetProductById(id);
        if (prod == null)
        {
            return View("Product Not Found");
        }
        return View(prod);
    }
    
    public IActionResult UpdateProductToDatabase(Product product)
    {
        _productRepository.UpdateProduct(product);

        return RedirectToAction("ViewProduct", new { id = product.ProductID });
    }
}