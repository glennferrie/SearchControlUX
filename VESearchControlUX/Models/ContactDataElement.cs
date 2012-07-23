using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Dynamic;
using System.Data;

namespace VESearchControlUX.Models
{
    public class ContactDataElement : IFirmDataElement
    {
        private DataRow row;
        public void LoadDataElement(DataRow data)
        {
            row = data;
        }

        public string Title
        {
            get { return string.Format("{0}", row["Full Name"]); }
        }

        public string Description
        {
            get { return string.Format("{0} - {1}", row["Job Title"], row["E-mail"]); }
        }

        public string ImageUrl
        {
            get { return null; }
        }

        public string ElementType
        {
            get { return "Contact"; }
        }

        public override string ToString()
        {
            return this.ElementType + ": " + this.Title;
        }
    }
}