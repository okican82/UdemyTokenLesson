using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using udemyLessonAPI.Domain.Response;
using udemyLessonAPI.Domain.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace udemyLessonAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly ICitiesService citiesService;
        private readonly IMapper mapper;

        // GET: /<controller>/
        public CitiesController(ICitiesService citiesService, IMapper mapper)
        {
            this.citiesService = citiesService;
            this.mapper = mapper;


        }


        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            CitiesListResponse citiesListResponse  = await citiesService.ListAsync();

            if (citiesListResponse.Success)
            {
                return Ok(citiesListResponse.citiesList);
            }
            else
            {
                return BadRequest(citiesListResponse.Message);
            }


        }

        // buradan aşağı kalan kısmı sopnra dolduracağım.

    }
}
