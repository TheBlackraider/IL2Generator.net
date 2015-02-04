using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class AllPlaneDBReader
    {
        private System.IO.StreamReader _reader;
        private AllPlaneDB theClass;
        IList<AllPlaneDB> theList;

        public string Separator { get; set; }
        public string FileName { get; set; }


        public AllPlaneDBReader(string fileName, IList<AllPlaneDB> list)
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

                theClass = new AllPlaneDB();
                theClass.PlaneName = fields[0];
                theClass.Faction = fields[1] == "Allies" ? Factions.Allies : Factions.Axis ;

                if (fields[2] == "1")
                {
                    theClass.Multination = true;
                    theClass.Nation1 = fields[3];
                    theClass.Nation2 = fields[4];
                    theClass.Nation3 = fields[5];
                }
                else
                    theClass.Multination = false;

                theClass.Flyable = fields[6] == "1" ? true : false;
                theClass.Type1 = fields[7];
                theClass.Type2 = fields[8];
                theClass.Type3 = fields[9];
                theClass.Type4 = fields[10];

                theClass.Range = System.Convert.ToInt32(fields[11]);
                theClass.CruiseSpeed = System.Convert.ToInt32(fields[12]);
                theClass.FuelMass = System.Convert.ToInt32(fields[13]);
                theClass.DT1Fuel = System.Convert.ToInt32(fields[14]);
                theClass.DT2Fuel = System.Convert.ToInt32(fields[15]);
                theClass.DT3Fuel = System.Convert.ToInt32(fields[16]);

                theList.Add(theClass);
            }
        }
    }
}
