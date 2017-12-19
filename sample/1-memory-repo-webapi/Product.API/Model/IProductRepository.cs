using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceStructure.Service.Product.API.Model
{
    public interface IProductRepository
    {
        Task<Product> GetProductAsync(string name);
        Task<Product> UpdateProductAsync(Product basket);
        Task<bool> DeleteProductAsync(string id);
    }
}
