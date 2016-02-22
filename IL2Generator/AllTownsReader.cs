using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class AllTownsReader
    {
        private System.IO.StreamReader _reader;
        private AllTowns theClass;
        IList<AllTowns> theList;

        public string Separator { get; set; }
        public string FileName { get; set; }


        public AllTownsReader(string fileName, IList<AllTowns> list)
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

                theClass = new AllTowns();
                theClass.X = System.Convert.ToInt32(fields[0]);
                theClass.Y = System.Convert.ToInt32(fields[1]);
                theClass.X = System.Convert.ToInt32(fields[2]);
                theClass.Name = fields[3];

                theList.Add(theClass);
            }
        }
    }
}
