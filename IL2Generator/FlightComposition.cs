using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class FlightComposition
    {
        public string FlightName { get; set; }
        public int Flags { get; set; }
        public int Delay { get; set; }
        public List<string> Skins { get; set; }
        public string Brief { get; set; }
        public string TargetData { get; set; }
        public string CarrierData { get; set; }
        //public string planes: Plane;
        public int NumPlanes { get; set; }
        public int Skill { get; set; }
        //public string routes: Route;
        public string Role { get; set; }
        public int Groupindex { get; set; }
        public int InGroupindex { get; set; }
        public string Leader { get; set; }

        public FlightComposition()
        {
            Skins = new List<string>();
        }
    }
}
