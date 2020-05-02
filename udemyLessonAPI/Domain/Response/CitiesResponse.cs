using System;
namespace udemyLessonAPI.Domain.Response
{
    public class CitiesResponse:BaseResponse
    {
        public Cities cities { get; set; }



        private CitiesResponse(bool Success, string Message, Cities cities) : base(Success, Message)
        {
            this.cities = cities;
        }

        public CitiesResponse(Cities cities) : this(true, String.Empty, cities) { }

        public CitiesResponse(string message) : this(false, message, null) { }
    }
}
