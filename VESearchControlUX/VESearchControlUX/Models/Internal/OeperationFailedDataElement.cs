using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VESearchControlUX.Models;

namespace VESearchControlUX.Models.Internal
{
    internal class OperationFailedDataElement : IFirmDataElement
    {
        public OperationFailedDataElement(string title = null, string desc = "")
        {
            Title = title ?? "Untitled";
            Description = desc;
        }
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public static IFirmDataElement ThrowNewException(string title, string desc)
        {
            return new OperationFailedDataElement(title, desc);
        }
    }
}
