using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace VESearchControlUX.Models
{
    public interface IFirmDataElement
    {
        string Title { get; }

        string Description { get; }

        string ImageUrl { get; }

        string ElementType { get; }

        void LoadDataElement(DataRow data);
        
    }
}
