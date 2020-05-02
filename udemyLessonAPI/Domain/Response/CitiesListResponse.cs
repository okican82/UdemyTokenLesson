using System;
using System.Collections.Generic;

namespace udemyLessonAPI.Domain.Response
{
    public class CitiesListResponse:BaseResponse
    {
        public IEnumerable<Cities> citiesList { get; set; }


        private CitiesListResponse(bool Success, string Message, IEnumerable<Cities> citiesList):base(Success, Message)
        {
            this.citiesList = citiesList;
        }

        public CitiesListResponse(IEnumerable<Cities> citiesList):this(true, string.Empty, citiesList)
        {

        }

        public CitiesListResponse(string message) : this(false, message, null) { }

    }
}
