using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VESearchControlUX.Controllers
{
    public class SearchRequest
    {
        public string q { get; set; }
        public List<string> TypeFilters { get; set; }
    }
}
