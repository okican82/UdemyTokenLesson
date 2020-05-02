using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using udemyLessonAPI.Domain;
using udemyLessonAPI.Domain.Repositories;
using udemyLessonAPI.Domain.Response;
using udemyLessonAPI.Domain.Service;
using udemyLessonAPI.Domain.UnitOfWork;

namespace udemyLessonAPI.Service
{
    public class CitiesService : ICitiesService
    {
        private readonly ICitiesRepository citiesRepository;
        private readonly IUnitOfWork unitOfWork;

        public CitiesService(ICitiesRepository citiesRepository, IUnitOfWork unitOfWork)
        {
            this.citiesRepository = citiesRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CitiesResponse> AddProduct(Cities cities)
        {
            try
            {
                await citiesRepository.AddCitiesAsync(cities);
                await unitOfWork.CompleteAsync();

                return new CitiesResponse(cities);

            }
            catch(Exception ex)
            {
                return new CitiesResponse($"Ürün Eklenirken Hata Oluştu{ ex.Message }");
            }
        }

        public async Task<CitiesResponse> findByIdAsync(int id)
        {
            try
            {
                Cities cities = await citiesRepository.FindByIdAsync(id);
                if (cities == null)
                {
                    return new CitiesResponse("Cities Bulunamadı");
                }
                return new CitiesResponse(cities);
            }
            catch(Exception ex)
            {
                return new CitiesResponse($"Cities Bulunurken İşlem Sırasında Hata Oluştu{ ex.Message }");
            }

        }

        public async Task<CitiesListResponse> ListAsync()
        {
            try
            {
                IEnumerable<Cities> cities = await citiesRepository.ListAsync();

                return new CitiesListResponse(cities);

            }
            catch(Exception ex)
            {
                return new CitiesListResponse($"Cities Listelenirken İşlem Sırasında HCata Oluştu{ ex.Message }");
            }
        }

        public async Task<CitiesResponse> RemoveProduct(int id)
        {
            try
            {
                Cities cities = await citiesRepository.FindByIdAsync(id);
                if(cities == null)
                {
                    return new CitiesResponse("Cities Bulunamadı");
                }
                else
                {
                    await citiesRepository.RemoveCitiesAsync(id);
                    await unitOfWork.CompleteAsync();

                }

                return new CitiesResponse(cities);



            }
            catch(Exception ex)
            {
                return new CitiesResponse($"Cities Silinirken İşlem Sırasında Hata Oluştu{ ex.Message }");
            }
            
        }

        public async Task<CitiesResponse> UpdateProduct(Cities cities, int id)
        {
            try
            {
                Cities firstCities = await citiesRepository.FindByIdAsync(id);
                if(firstCities == null)
                {
                    return new CitiesResponse("Cities Bulunamadı");
                }
                else
                {
                    firstCities.Name = cities.Name;
                    firstCities.CountryId = cities.CountryId;

                    citiesRepository.UpdateCities(firstCities);
                    await unitOfWork.CompleteAsync();

                    return new CitiesResponse(firstCities);
                }


            }
            catch (Exception ex)
            {
                return new CitiesResponse($"Cities update İşlem Sırasında Hata Oluştu{ ex.Message }");
            }
        }
    }
}
