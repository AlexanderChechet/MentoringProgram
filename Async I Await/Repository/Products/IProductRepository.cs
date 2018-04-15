using Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopRepository.Products
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(int id);
    }
}
