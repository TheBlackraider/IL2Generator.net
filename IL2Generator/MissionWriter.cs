using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class MissionWriter : IDisposable
    {
        private System.IO.StreamWriter _writer;
        private Mission theClass;
        IList<Mission> theList;

        public string Separator { get; set; }
        public string FileName { get; set; }


        public MissionWriter(string fileName, IList<Mission> list)
        {
            FileName = fileName;
            Separator = ";";
            _writer = new System.IO.StreamWriter(FileName);
            theList = list;
        }

        public void WriteAll()
        {
            
            foreach (Mission m in theList)
            {
                theClass = m;
                writeHeader("MAIN");
                writeMainData();
                writeHeader("SESSION");
                writeSessionData();
                writeHeader("WEATHER");
                writeWeatherData();
                writeHeader("Wing");
                writeWingData();
                //
                foreach (AllWings wing in theClass.Wings)
                {
                    writeHeader(wing.Name);
                    writeFlightComposition(wing.Flight);
                    writeHeader(wing.Name + "_Way");
                    writeWingWaypoint(wing);
                }



            }

            _writer.Flush();
            
        }

        private void writeHeader(string Text)
        {
            _writer.WriteLine("[" + Text + "]");
        }

        private void writeMainData()
        {
            writeTabStrings("MAP", theClass.Map);
            writeTabStrings("TIME", theClass.Time.ToString());
            writeTabStrings("CloudType", theClass.CloudType.ToString());
            writeTabStrings("CloudHeight", theClass.CloudHeight.ToString());
            writeTabStrings("player", theClass.Player);
            writeTabStrings("army", theClass.Side.ToString());
            writeTabStrings("playerNum", theClass.PlayerNum.ToString());

        }

        private void writeSessionData()
        {
            writeTabStrings("Year", theClass.Year);
            writeTabStrings("Month", theClass.Month);
            writeTabStrings("Day", theClass.Day);

        }

        private void writeWeatherData()
        {
            writeTabStrings("WindDirection", theClass.WindDirection.ToString());
            writeTabStrings("WindSpeed", theClass.WindSpeed.ToString());
            writeTabStrings("Gust", theClass.Gust.ToString());
            writeTabStrings("Turbulence", theClass.Turbulence.ToString());

        }

        private void writeTabStrings(string a, string b)
        {
            _writer.WriteLine("\t{0}\t{1}",a,b);
        }

        void IDisposable.Dispose()
        {
            _writer.Flush();
            _writer.Close();

            GC.SuppressFinalize(this);
        }

        void writeWingData()
        {
            foreach (AllWings wing in theClass.Wings)
            {
                _writer.WriteLine("\t{0}",wing.Name);
            }
        }

        void writeFlightComposition(FlightComposition flight)
        {
            writeTabStrings("Planes", flight.NumPlanes.ToString());
           
            
            Dictionary<string,int> SkillValues = new Dictionary<string,int>();

            Random rand = new Random();


            for (int n = 0; n < flight.NumPlanes; n++)
            {
                string str = "Skill" + n.ToString();
                SkillValues.Add("Skill" + n.ToString(), 0);

                switch (flight.Skill)
                {
                    case 0:
                        if (rand.Next(1, 2) == 1) SkillValues["Skill" + n.ToString()] = 1;
                        break;

                    case 1:
                        if (rand.Next(1, 4) == 1) SkillValues["Skill" + n.ToString()] = 0;
                        break;

                    case 2:
                        if (rand.Next(1, 4) == 1) SkillValues["Skill" + n.ToString()] = 1;
                        break;

                    case 3:
                        if (rand.Next(1, 3) != 1) SkillValues["Skill" + n.ToString()] = 1;
                        break;

                    default:
                        SkillValues["Skill" + n.ToString()] = 1;
                        break;
                }
                
                writeTabStrings(str, SkillValues[str].ToString());
            }
        }

        private void writeWingWaypoint(AllWings wing)
        {
            if (wing.Waypoints != null)
            {
                foreach (Waypoint w in wing.Waypoints)
                {
                    writeWaypointData(w);
                }
            }
        }

        private void writeWaypointData(Waypoint way)
        {
            _writer.WriteLine("\t{0} {0} {0} {0} {0} &0", way.type.ToString(), way.x, way.y, way.alt, way.speed); 
        }
    }
}
