using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace udemyLessonAPI.Domain.Repositories
{
    public class CitiesRepository: BaseRepository,ICitiesRepository
    {
        public CitiesRepository(UdemyAPIWithTokenContext context) : base(context)
        {

        }

        public async Task AddCitiesAsync(Cities cities)
        {
            await context.Cities.AddAsync(cities);
        }

        public async Task<Cities> FindByIdAsync(int id)
        {
            return await context.Cities.FindAsync(id);
        }

        public async Task<IEnumerable<Cities>> ListAsync()
        {
            return await context.Cities.ToListAsync();
        }

        public async Task RemoveCitiesAsync(int id)
        {
            Cities cities = await FindByIdAsync(id);
            context.Cities.Remove(cities);
        }

        public void UpdateCities(Cities cities)
        {
            context.Cities.Update(cities);
        }
    }
}
