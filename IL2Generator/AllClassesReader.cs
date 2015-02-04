using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class AllClassesReader
    {
        private System.IO.StreamReader _reader;
        private AllClasses theClass;
        IList<AllClasses> theList;

        public string Separator { get; set; }
        public string FileName { get; set; }


        public AllClassesReader(string fileName, IList<AllClasses> list)
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

                theClass = new AllClasses();
                theClass.PlaneName = fields[0];
                theClass.IsFighter = System.Convert.ToBoolean(fields[1]);
                theClass.Class = fields[2];
                theClass.DefensiveArms = fields[3] == "1";
                theClass.IsNaval = fields[4] == "1";
                theClass.IsHydro = fields[5] == "1";

                theList.Add(theClass);
            }
        }
    }
}
