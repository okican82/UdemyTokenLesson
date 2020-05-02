using System;
namespace udemyLessonAPI.Domain.Response
{
    public class ProductResponse:BaseResponse
    {
        public Product Product { get; set; }

        private ProductResponse(bool Success, string Message, Product product) : base(Success, Message)
        {
            this.Product = product;
        }

        

        //Başarılı olursa

        public ProductResponse(Product product):this(true,String.Empty,product) { }

        //Başarısız olursa

        public ProductResponse(string message):this(false,message,null) { }


    }
}
