using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace udemyLessonAPI.Extension
{
    public static class ModelStateExtension
    {
        public static List<string> GetrrorMessage(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors).Select(x=>x.ErrorMessage).ToList();


        }
    }
}
