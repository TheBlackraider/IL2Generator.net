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
    }
}
