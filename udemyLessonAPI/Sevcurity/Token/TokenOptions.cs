using System;
namespace udemyLessonAPI.Sevcurity.Token
{
    public class TokenOptions
    {
        public string Audience{get;set;}

        public string Issuer { get; set; }

        public int AccessTokenExpiression { get; set; }

        public int RefreshTokenExpiression { get; set; }

        public string SecurityKey { get; set; }


    }
}
