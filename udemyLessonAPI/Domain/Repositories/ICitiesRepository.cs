using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace udemyLessonAPI.Domain.Repositories
{
    public interface ICitiesRepository
    {
        Task<IEnumerable<Cities>> ListAsync();

        Task AddCitiesAsync(Cities cities);

        Task RemoveCitiesAsync(int id);

        void UpdateCities(Cities cities);

        Task<Cities> FindByIdAsync(int id);
    }
}
