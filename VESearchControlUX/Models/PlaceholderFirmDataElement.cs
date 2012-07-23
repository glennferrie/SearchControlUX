using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VESearchControlUX.Models
{
    public class PlaceholderFirmDataElement : IFirmDataElement 
    {
        private string title, desc, img, type;
        public PlaceholderFirmDataElement(string elementTitle)
        {
            title = elementTitle;
            desc = string.Empty;
            img = null;
            type = "Placeholder";
        }
        public string Title
        {
            get { return title; }
        }

        public string Description
        {
            get { return desc; }
        }

        public string ImageUrl
        {
            get { return img; }
        }

        public string ElementType
        {
            get { return type; }
        }

        public void LoadDataElement(System.Data.DataRow data)
        {
            throw new NotImplementedException();
        }
    }
}