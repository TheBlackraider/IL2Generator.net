using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class PilotProfileReader
    {
        private System.IO.StreamReader _reader;
        private PilotProfile theClass;

        public string Separator { get; set; }
        public string FileName { get; set; }


        public PilotProfileReader(PilotProfile profile, string fileName)
        {
            FileName = fileName;
            Separator = ";";
            theClass = profile;

            try
            {
                _reader = new System.IO.StreamReader(FileName);
            }
            catch
            {
                throw new System.Exception("No existe el archivo especificado : " + FileName);
            }
        }

        public void ReadAll()
        {
            string line;

            int i = 0;

            if ((line = _reader.ReadLine()) != null)
            {
                string[] fields = line.Split(',');

                theClass.FirstName = fields[1];
                theClass.LastName = fields[0];
                theClass.Born = fields[3];
            }

            if ((line = _reader.ReadLine()) != null)
            {
                theClass.Squadron = line;
            }

            if ((line = _reader.ReadLine()) != null)
            {
                string[] fields = line.Split('=');

                theClass.Directory = fields[1];
            }

            if ((line = _reader.ReadLine()) != null)
            {
                string[] fields = line.Split('=');

                theClass.Language = fields[1];

            }

            if ((line = _reader.ReadLine()) != null)
            {
                string[] fields = line.Split('=');
                
                theClass.Instant = System.Boolean.Parse(fields[1]);
            }

            while ((line = _reader.ReadLine()) != null)
            {
                if (line.Length == 0) { break; }

                string[] fields = line.Split(' ');

                Campaigns c = new Campaigns();

                c.Name = fields[0];
                c.Plane = fields[1];

                theClass.Campaigns.Add(c);
            }
        }
    }
}
