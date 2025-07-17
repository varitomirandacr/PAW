using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Models.PAWModels
{
    public class ConditionViewModel
    {
        public string Criteria { get; set; }  // Equals, Contains, GreaterThanOrEqual, LessThanOrEqual
        public string Property { get; set; }  // e.g., "Price", "Name"
        public string Value { get; set; }     // Used for Equals, Contains
        public decimal Start { get; set; }    // Used for >= and <=
        public decimal End { get; set; }
    }
}
