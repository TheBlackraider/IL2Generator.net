using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class AllPlaneDBClass
    {
        private AllPlaneDBReader _reader;
        private AllPlaneDBContainer _container;
        //private AllPlaneDB theClass;

        public AllPlaneDBClass(string fname)
        {
            _container = new AllPlaneDBContainer();
            _reader = new AllPlaneDBReader(fname, _container);
        }

        public void ReadAll()
        {
            _reader.ReadAll();
        }

        public void WriteAll()
        {

        }

        public AllPlaneDB Read(string key)
        {
            return _container.Find(o => o.PlaneName == key);
            
        }

        public bool Write(string key)
        {
            return false;
        }

        public IEnumerable<AllPlaneDB> GetEnumerable()
        {
            return _container.AsEnumerable<AllPlaneDB>();
        }
    }
}
