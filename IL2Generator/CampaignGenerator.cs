using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class CampaignGenerator
    {

        private string _cID;
        private string _lang;

        public bool NewMap { get; set; }
        public string enNation { get; set; }
        public int AFOFFNum { get; set; }
        public bool mapAxAirStart { get; set; }
        public bool mapAlAirStart { get; set; }
        public string MapSeason { get; set; }
        public string MapNight { get; set; }
        public int Weather0 { get; set; }
        public int Weather1 { get; set; }
        public int Weather2 { get; set; }
        public int Weather3 { get; set; }
        public int Weather4 { get; set; }
        public int Weather5 { get; set; }
        public int Weather6 { get; set; }
        public int Wind0 { get; set; }
        public int Wind1 { get; set; }
        public int Wind2 { get; set; }
        public int Wind3 { get; set; }
        public bool RndScramble { get; set; }

        public CampaignGenerator()
        {
            NewMap = false;
            enNation= "";
            AFOFFNum = 0;
            mapAxAirStart = false;
            mapAlAirStart = false;
            MapSeason = "Summer";
            MapNight = "Random";
            Weather0 = 30;
            Weather1 = 40;
            Weather2 = 16;
            Weather3 = 5;
            Weather4 = 3;
            Weather5 = 3;
            Weather6 = 3;
            Wind0 = 60;
            Wind1 = 30;
            Wind2 = 8;
            Wind3 = 2;
            RndScramble = true;

        }

        public bool InstantVictory { get; set; }

        public string CampaignID
        {
            get { return _cID; }
        }

        public void MakeID(string dir)
        {
            string[] fields = dir.Split('\\');
            string it1 = fields[2];
            string it2 = fields.Last().Split('_').Last();

            _cID = it1 + "_" + it2;
        }

        public string Language
        {
            get
            {
                return _lang;
            }

            set
            {
                if (value.Length > 3)
                {
                    switch (value)
                    {
                        case "Russian": { _lang = "RUS"; break; }
                        case "German": { _lang = "RUS"; break; }
                        case "French": { _lang = "RUS"; break; }
                        case "Czech": { _lang = "RUS"; break; }
                        case "Polish": { _lang = "RUS"; break; }
                        case "Hungarian": { _lang = "RUS"; break; }
                        case "Japanese": { _lang = "RUS"; break; }
                        default: { _lang = "ENG"; break; }
                    }
                }
                else
                {
                    _lang = value;
                }
            }
        }
    }
}
