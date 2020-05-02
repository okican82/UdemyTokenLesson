using System;
using AutoMapper;
using udemyLessonAPI.Domain;
using udemyLessonAPI.Resource;

namespace udemyLessonAPI.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductResource, Product>();
            CreateMap<Product,ProductResource>();
        }
    }
}
