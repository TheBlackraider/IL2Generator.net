using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class PilotProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Born { get; set; }
        public string Squadron { get; set; }
        public string Directory { get; set; }
        public string Language { get; set; }
        public bool Instant { get; set; }
        public CampaignsList Campaigns { get; set; }

        public PilotProfile()
        {
            Campaigns = new CampaignsList();
        }
    }
}
