using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class AllWeaponsReader
    {
        private System.IO.StreamReader _reader;
        private AllWeapons theClass;
        IList<AllWeapons> theList;

        public string Separator { get; set; }
        public string FileName { get; set; }


        public AllWeaponsReader(string fileName, IList<AllWeapons> list)
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

                theClass = new AllWeapons();
                theClass.Name = fields[0];
                theClass.minAlt = System.Convert.ToInt32(fields[1]);
                theClass.attAtl = System.Convert.ToInt32(fields[2]);
                theClass.SwitchMov = fields[3] == "1" ? true : false;
                theClass.SwitchArm = fields[4] == "1" ? true : false;
                theClass.SwitchGro = fields[5] == "1" ? true : false;
                theClass.SwitchBri = fields[6] == "1" ? true : false;
                theClass.SwitchShi = fields[7] == "1" ? true : false;
                theClass.SwitchPoi = fields[8] == "1" ? true : false;
                theClass.SwitchGo = fields[9] == "1" ? true : false;
                theClass.SwitchRec = fields[10] == "1" ? true : false;
                theClass.SwitchStuf = fields[11] == "1" ? true : false;
                theClass.SwitchTran = fields[12] == "1" ? true : false;
                theClass.SwitchPara = fields[13] == "1" ? true : false;
                theClass.SwitchInt = fields[14] == "1" ? true : false;
                theClass.SwitchTorp = fields[15] == "1" ? true : false;
                theClass.SwitchLR1 = fields[16] == "1" ? true : false;
                theClass.SwitchLR2 = fields[17] == "1" ? true : false;
                theClass.SwitchLR3 = fields[18] == "1" ? true : false;

                theClass.WeaponsSelected = fields[19];

                if (fields[20] == "") fields[20] = "All";

                theClass.Nation = (Nations) Enum.Parse(typeof(Nations), fields[20], true);

                theList.Add(theClass);
            }
        }
    }
}
