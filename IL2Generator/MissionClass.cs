using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class MissionClass: IDisposable
    {
        private MissionReader _reader;
        private MissionContainer _container;
        private MissionWriter _writer;

        //private AllClasses theClass;

        public MissionClass(string fname)
        {
            _container = new MissionContainer();
            //_reader = new MissionReader(fname, _container);
            _writer = new MissionWriter(fname, _container);

        }

        public void ReadAll()
        {
            _reader.ReadAll();
        }

        public void WriteAll()
        {
            _writer.WriteAll();
        }

        public Mission Read(string key)
        {
            return null; //_container.Find(o => o.PlaneName == key);
            
        }

        public void Write(Mission m)
        {
            _container.Add(m);
        }

        public IEnumerable<Mission> GetEnumerable()
        {
            return _container.AsEnumerable<Mission>();
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
