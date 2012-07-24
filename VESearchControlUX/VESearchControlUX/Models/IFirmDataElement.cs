using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VESearchControlUX.Models
{
    public interface IFirmDataElement
    {
        string Title { get; set; }

        string Description { get; set; }

        string ImageUrl { get; set; }

        
    }
}
