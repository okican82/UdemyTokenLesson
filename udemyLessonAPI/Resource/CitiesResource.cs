using System;
using System.ComponentModel.DataAnnotations;

namespace udemyLessonAPI.Resource
{
    public class CitiesResource
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}
