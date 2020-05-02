using System;
using System.Threading.Tasks;
using udemyLessonAPI.Domain.Response;

namespace udemyLessonAPI.Domain.Service
{
    public interface ICitiesService
    {
        Task<CitiesListResponse> ListAsync();

        Task<CitiesResponse> AddProduct(Cities cities);

        Task<CitiesResponse> RemoveProduct(int id);

        Task<CitiesResponse> UpdateProduct(Cities cities, int id);

        Task<CitiesResponse> findByIdAsync(int id);
    }
}
