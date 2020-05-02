using System;
using System.Collections.Generic;

namespace udemyLessonAPI.Domain.Response
{
    public class ProductListResponse:BaseResponse
    {
        public IEnumerable<Product> productList { get; set; }

        private ProductListResponse(bool Success, string Message, IEnumerable<Product> productList) : base(Success, Message)
        {
            this.productList = productList;
        }

        public ProductListResponse(IEnumerable<Product> productList) : this(true,string.Empty, productList)
        {

        }

        public ProductListResponse(string message):this(false,message,null) { }


    }
}
