using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace udemyLessonAPI.Domain.Repositories
{
    public class ProductRepository:BaseRepository, IProductRepository
    {
        public ProductRepository(UdemyAPIWithTokenContext context) : base(context)
        {

        }

        public async Task AddProductAsync(Product product)
        {
            await context.Product.AddAsync(product);// bu fonksiyon Hazır.
        }

        public async Task<Product> findByIdAsync(int productId)
        {
            return await context.Product.FindAsync(productId);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await context.Product.ToListAsync();
        }

        public async Task RemoveProductAsync(int productId)
        {
            var product = await findByIdAsync(productId);

            context.Product.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            context.Product.Update(product);
            
        }
    }
}
