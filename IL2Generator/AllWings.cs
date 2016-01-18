using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace IL2Generator
{

    public enum WingTypes
    {
        wFighter,
        wAttack,
        wBomber,
        wDBomber,
        wTransport,
        wCarrier,
        wAll
    }

    [DebuggerDisplay("Value = {Name}")]
    public class AllWings
    {
        public string Name { get; set; }
        public WingTypes WingType { get; set; }
        public Factions Faction { get; set; }
        public Nations Nation { get; set; }

        //
        public FlightComposition Flight { get; set; }

        //
        public WaypointContainer Waypoints { get; set; }
        
    }
}
