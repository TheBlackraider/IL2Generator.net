using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class AllAirfieldsReader
    {
        private System.IO.StreamReader _reader;
        private AllAirfields theClass;
        IList<AllAirfields> theList;

        public string Separator { get; set; }
        public string FileName { get; set; }


        public AllAirfieldsReader(string fileName, IList<AllAirfields> list)
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

                theClass = new AllAirfields();
                theClass.XTakeoff = System.Convert.ToInt32(fields[0]);
                theClass.YTakeoff = System.Convert.ToInt32(fields[1]);
                theClass.XLanding = System.Convert.ToInt32(fields[2]);
                theClass.YLanding = System.Convert.ToInt32(fields[3]);
                theClass.Name = fields[4];

                theList.Add(theClass);
            }
        }

    }
}
