using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GillyBeanCentral.Extensions
{
    public static class ReflectionExtensions
    {
        public static string GetPropertyValue<T> 
            (this T item, string propertyNameToFetch)
        {
            return item.GetType()
                    .GetProperty(propertyNameToFetch)
                    .GetValue(item, null).ToString();
        }
    }
}