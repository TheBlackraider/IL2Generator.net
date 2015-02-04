using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace IL2Generator
{
    public enum Nations {   USSR,
                            France, 
                            USA, 
                            England, 
                            Finland, 
                            Hungary, 
                            Slovakia, 
                            Romania, 
                            Poland, 
                            Germany, 
                            Italy, 
                            Japan, 
                            Australia, 
                            NewZealand, 
                            Holland, 
                            All}

    [DebuggerDisplay("Value = {Name}")] 
    public class AllWeapons
    {
        public string Name { get; set; }
        public int minAlt { get; set; }
        public int attAtl { get; set; }
        public bool SwitchMov { get; set; }
        public bool SwitchArm { get; set; }
        public bool SwitchGro { get; set; }
        public bool SwitchBri { get; set; }
        public bool SwitchShi { get; set; }
        public bool SwitchPoi { get; set; }
        public bool SwitchGo { get; set; }
        public bool SwitchRec { get; set; }
        public bool SwitchStuf { get; set; }
        public bool SwitchTran { get; set; }
        public bool SwitchPara { get; set; }
        public bool SwitchInt { get; set; }
        public bool SwitchTorp { get; set; }
        public bool SwitchLR1 { get; set; }
        public bool SwitchLR2 { get; set; }
        public bool SwitchLR3 { get; set; }
        public string WeaponsSelected { get; set; }
        public Nations Nation { get; set; }
    }
}
