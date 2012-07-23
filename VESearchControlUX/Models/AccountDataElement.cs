using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Dynamic;
using System.Data;

namespace VESearchControlUX.Models
{
    public class AccountDataElement : IFirmDataElement
    {
        private DataRow row;
        public void LoadDataElement(DataRow data)
        {
            row = data;
        }

        public string Title
        {
            get { return string.Format("{0} - {1}", row["Account Number"], row["Account Name"]); }
        }

        public string Description
        {
            get { return string.Format("{0} - {1}", row["Industry"], row["Owner"]); }
        }

        public string ImageUrl
        {
            get { return null; }
        }

        public string ElementType
        {
            get { return "Account"; }
        }

        public override string ToString()
        {
            return this.ElementType + ": " + this.Title;
        }
    }
}