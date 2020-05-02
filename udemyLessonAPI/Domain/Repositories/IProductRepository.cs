using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace udemyLessonAPI.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();

        Task AddProductAsync(Product product);

        Task RemoveProductAsync(int productId);

        void UpdateProduct(Product product);

        Task<Product> findByIdAsync(int productId);

    }
}
