using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class AllWingsReader
    {
        private System.IO.StreamReader _reader;
        private AllWings theClass;
        IList<AllWings> theList;

        public string Separator { get; set; }
        public string FileName { get; set; }


        public AllWingsReader(string fileName, IList<AllWings> list)
        {
            FileName = fileName;
            Separator = ";";
            _reader = new System.IO.StreamReader(FileName);
            theList = list;
        }

        public void ReadAll()
        {
            string line;

            while ((line = _reader.ReadLine()) != null)
            {

                string[] fields = line.Split(Separator.ToCharArray());

                theClass = new AllWings();
                theClass.Name = fields[0];
                theClass.WingType = (WingTypes)Enum.Parse(typeof(WingTypes), fields[1], true);
                theClass.Faction = (Factions)Enum.Parse(typeof(Factions), fields[2], true);
                theClass.Nation = (Nations)Enum.Parse(typeof(Nations), fields[3], true);

                //if (fields[20] == "") fields[20] = "All";

                //theClass.Nation = (Nations) Enum.Parse(typeof(Nations), fields[20], true);

                theList.Add(theClass);
            }
        }
    }
}
