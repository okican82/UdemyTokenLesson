using System;
using System.Collections.Generic;

namespace udemyLessonAPI.Domain
{
    public partial class Neighbourhood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
    }
}
