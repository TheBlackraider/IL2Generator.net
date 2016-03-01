using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class CampaignSettingsReader
    {
        private System.IO.StreamReader _reader;
        private CampaignGenerator theClass;

        public string Separator { get; set; }
        public string FileName { get; set; }


        public CampaignSettingsReader(string fileName, CampaignGenerator cg)
        {
            FileName = fileName;
            Separator = ";";
            _reader = new System.IO.StreamReader(FileName);
            theClass = cg;

        }

        public void ReadAll()
        {
            string line;

            while ((line = _reader.ReadLine()) != null)
            {
                string[] fields = line.Split(Separator.ToCharArray());

            }
        }
    }
}
