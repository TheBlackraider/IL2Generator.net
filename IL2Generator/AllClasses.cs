using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace IL2Generator
{
    [DebuggerDisplay("Value = {PlaneName}")]    
    public class AllClasses
    {
        public string PlaneName { get; set; }
        public bool IsFighter {get; set;}
        public string Class { get; set; }
        public bool DefensiveArms { get; set; }
        public bool IsNaval { get; set; }
        public bool IsHydro { get; set; }
    }
}
