using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace IL2Generator
{
    public enum Factions { Allies, Axis}

    [DebuggerDisplay("Value = {PlaneName}")] 
    public class AllPlaneDB
    {
        public string PlaneName { get; set; }
        public Factions Faction { get; set; }
        public bool Multination { get; set; }
        public string Nation1 { get; set; }
        public string Nation2 { get; set; }
        public string Nation3 { get; set; }
        public bool Flyable { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public string Type4 { get; set; }
        public int Range { get; set; }
        public int CruiseSpeed { get; set; }
        public int FuelMass { get; set; }
        public int DT1Fuel { get; set; }
        public int DT2Fuel { get; set; }
        public int DT3Fuel { get; set; }
        public double minAlt { get; set; }
        public double attAlt { get; set; }
    }
}
