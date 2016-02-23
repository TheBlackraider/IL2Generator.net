using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class AllNationsReader
    {
        private System.IO.StreamReader _reader;
        private AllNations theClass;
        IList<AllNations> theList;

        public string Separator { get; set; }
        public string FileName { get; set; }


        public AllNationsReader(string fileName, IList<AllNations> list)
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
                if (line.Length == 0) { break; }
                                
                string[] fields = line.Split(Separator.ToCharArray());

                theClass = new AllNations();
                theClass.Nation = fields[0];
                theClass.Branch = fields[1];
                theClass.Faction = (Factions) Enum.Parse(typeof(Factions), fields[2]);
                theClass.Config = fields[3];

                theList.Add(theClass);
            }
        }
    }
}
