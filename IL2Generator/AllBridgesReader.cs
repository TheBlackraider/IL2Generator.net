using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class AllBridgesReader
    {
        private System.IO.StreamReader _reader;
        private AllBridges theClass;
        IList<AllBridges> theList;

        public string Separator { get; set; }
        public string FileName { get; set; }


        public AllBridgesReader(string fileName, IList<AllBridges> list)
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

                theClass = new AllBridges();
                theClass.Name = fields[0];
                theClass.X = System.Convert.ToInt32(fields[1]);
                theClass.Y = System.Convert.ToInt32(fields[2]);
                
                theList.Add(theClass);
            }
        }


    }
}
