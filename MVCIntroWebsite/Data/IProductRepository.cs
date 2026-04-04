using MVCIntroWebsite.Models;
namespace MVCIntroWebsite.Data;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();
    public Product GetProductById(int id);
}