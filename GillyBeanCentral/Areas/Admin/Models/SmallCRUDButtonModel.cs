using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GillyBeanCentral.Areas.Admin.Models
{
    //This class takes a bunch of parameters and generates a CRUD action button
    //Tutorial slide 32
    public class SmallCRUDButtonModel
    {
        //these next properties define how the button should look and behave
        public string Action { get; set; }
        public string Text { get; set; }
        public string Glyph { get; set; }
        public string ButtonType { get; set; }

        //these next properties are for each of the types of
        //items that could require a CRUD button

        public int? ID { get; set; }
        public int? VenueID { get; set; }
        public int? VenueTypeID { get; set; }
        //this next property will build the URL query string for
        //the action to be executed.  
        //Since it is read only, the set parameter has been removed
        public string ActionParameters
        {
            get
            {
                {
                    var param = new StringBuilder("?");
                    if ((ID != null && ID > 0))
                        param.Append(string.Format("{0}={1}&", "id", ID));

                    if ((VenueID != null && VenueID > 0))
                        param.Append(string.Format("{0}={1}&", "venueId", VenueID));

                    if ((VenueTypeID != null && VenueTypeID > 0))
                        param.Append(string.Format("{0}={1}&", "venueTypeId", VenueTypeID));

                    //return final string without final ampersand
                    return param.ToString().Substring(0, param.Length - 1);
                }
            }


        }

    }
}