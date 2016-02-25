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
                        case "Polish" { _lang = "RUS"; break; }
                        case "Hungarian" { _lang = "RUS"; break; }
                        case "Japanese" { _lang = "RUS"; break; }
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
