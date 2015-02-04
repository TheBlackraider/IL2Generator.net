using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class Mission
    {
        //Cabecera MAIN

        public string Map {get; set;}   // MAP
        public string Time { get; set; }    //TIME 99.99
        public int CloudType { get; set; }  //CloudType
        public double CloudHeight { get; set; } //CloudHeight
        public string Player { get; set; }  //player
        public int Side { get; set; }   //army
        public int PlayerNum { get; set; }  //playerNum

        // Cabecera SEASON
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }

        // Cabecera WEATHER
        public int WindDirection { get; set; }
        public double WindSpeed { get; set; }
        public int Gust { get; set; }
        public int Turbulence { get; set; }

        // Relaciones

    }
}
