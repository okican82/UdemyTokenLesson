using System;
using System.ComponentModel.DataAnnotations;

namespace udemyLessonAPI.Resource
{
    public class ProductResource
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }


        public decimal? Price { get; set; }
    }
}
