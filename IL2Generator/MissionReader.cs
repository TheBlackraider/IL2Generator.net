using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class MissionReader
    {
        private System.IO.StreamReader _reader;
        private Mission theClass;
        IList<Mission> theList;

        public string Separator { get; set; }
        public string FileName { get; set; }


        public MissionReader(string fileName, IList<Mission> list)
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

                theClass = new Mission();

                theList.Add(theClass);
            }
        }
    }
}
