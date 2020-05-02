using System;
using System.Threading.Tasks;
using udemyLessonAPI.Domain.Response;

namespace udemyLessonAPI.Domain.Service
{
    public interface IProductService
    {
        Task<ProductListResponse> ListAsync();

        Task<ProductResponse> AddProduct(Product product);

        Task<ProductResponse> RemoveProduct(int ProductId);

        Task<ProductResponse> UpdateProduct(Product product, int ProductId);

        Task<ProductResponse> findByIdAsync(int ProductId);



    }
}
