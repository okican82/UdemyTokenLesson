using System;
namespace udemyLessonAPI.Domain.Response
{
    public class BaseResponse
    {

        public bool Success { get; set; }
        public string Message { get; set; }

        public BaseResponse(bool Success, string Message)
        {
            this.Success = Success;
            this.Message = Message;
            
        }



    }
}
