using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public enum WaypointType { TAKEOFF, NORMFLY, LANDING, GATTACK }

    public class Waypoint
    {
        public double x {get; set;}
        public double y { get; set; }
        public double speed { get; set; }
        public double alt { get; set; }
        public WaypointType type { get; set; }
    }
}
