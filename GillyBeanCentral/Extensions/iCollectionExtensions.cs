using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GillyBeanCentral.Extensions
{
    public static class ICollectionExtensions
    {
        //this class returns a collection of items that can be used
        //to populate a lookup list.
        public static IEnumerable<SelectListItem> ToSelectListItem<T>
            (this ICollection<T> myItems, int mySelectedValue)
            {
            return from myItem in myItems
                   select new SelectListItem
                   {
                       //the below use of Title and ID assumes that
                       //the entity (table) has 2 fields, called Title and ID
                       Text = myItem.GetPropertyValue("Title"),
                       Value = myItem.GetPropertyValue("Id"),
                       Selected = myItem.GetPropertyValue("Id").Equals(mySelectedValue.ToString())
                   };
            }
    }
}