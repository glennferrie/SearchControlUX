using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Dynamic;
using System.Data;

namespace VESearchControlUX.Models
{
    public class InvoiceDataElement : IFirmDataElement
    {
        private DataRow row;
        public void LoadDataElement(DataRow data)
        {
            row = data;
        }

        public string Title
        {
            get { return string.Format("{0} ({1}) - {2}", row["Name"], row["Customer"], row["Total Amount"]); }
        }

        public string Description
        {
            get { return string.Format("{0}", row["Description"]); }
        }

        public string ImageUrl
        {
            get { return null; }
        }

        public string ElementType
        {
            get { return "Invoice"; }
        }

        public override string ToString()
        {
            return this.ElementType + ": " + this.Title;
        }
    }
}