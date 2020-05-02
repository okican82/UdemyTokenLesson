using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using udemyLessonAPI.Domain.Service;
using AutoMapper;
using udemyLessonAPI.Domain.Response;
using udemyLessonAPI.Resource;
using udemyLessonAPI.Extension;
using udemyLessonAPI.Domain;

namespace udemyLessonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;


        public ProductController(IProductService productService,IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            ProductListResponse productListResponse = await productService.ListAsync();

            if(productListResponse.Success)
            {
                return Ok(productListResponse.productList);
            }
            else
            {
                return BadRequest(productListResponse.Message);
            }


        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFindById(int Id)
        {

            ProductResponse productResponse = await productService.findByIdAsync(Id);

            if(productResponse.Success)
            {
                return Ok(productResponse.Product);
            }
            else
            {
                return BadRequest(productResponse.Message);
            }

        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductResource productResource)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetrrorMessage());
            }
            else
            {
                Product product = mapper.Map<ProductResource, Product>(productResource);
                ProductResponse productResponse = await productService.AddProduct(product);

                if (productResponse.Success)
                {
                    return Ok(productResponse.Product);
                }
                else
                {
                    return BadRequest(productResponse.Message);
                }

            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(ProductResource productResource, int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetrrorMessage());
            }
            else
            {
                Product product = mapper.Map<ProductResource, Product>(productResource);
                ProductResponse productResponse = await productService.UpdateProduct(product, id);

                if(productResponse.Success)
                {
                    return Ok(productResponse.Product);
                }
                else
                {
                    return BadRequest(productResponse.Message);
                }
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            ProductResponse productResponse = await productService.RemoveProduct(id);

            if(productResponse.Success)
            {
                return Ok(productResponse.Product);
            }
            else
            {
                return BadRequest(productResponse.Message);
            }

        }


    }

}
