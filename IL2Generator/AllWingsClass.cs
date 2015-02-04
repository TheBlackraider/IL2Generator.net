using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class AllWingsClass
    {
        private AllWingsReader _reader;
        private AllWingsContainer _container;

        public AllWingsClass(string fname)
        {
            _container = new AllWingsContainer();
            _reader = new AllWingsReader(fname, _container);
        }

        public void ReadAll()
        {
            _reader.ReadAll();
        }

        public void WriteAll()
        {

        }

        public AllWings Read(string key)
        {
            return _container.Find(o => o.Name == key);
            
        }

        public bool Write(string key)
        {
            return false;
        }

        public IEnumerable<AllWings> GetEnumerable()
        {
            return _container.AsEnumerable<AllWings>();
        }
    }
}
