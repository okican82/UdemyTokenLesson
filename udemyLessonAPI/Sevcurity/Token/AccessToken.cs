﻿using System;
namespace udemyLessonAPI.Sevcurity.Token
{
    public class AccessToken
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }

        public string RefreshToken { get; set; }


    }
}
