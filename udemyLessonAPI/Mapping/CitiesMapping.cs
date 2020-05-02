using System;
using AutoMapper;
using udemyLessonAPI.Domain;
using udemyLessonAPI.Resource;

namespace udemyLessonAPI.Mapping
{
    public class CitiesMapping: Profile
    {
        public CitiesMapping()
        {
            CreateMap<CitiesResource, Cities>();
            CreateMap<Cities, CitiesResource>();
        }
    }
}
