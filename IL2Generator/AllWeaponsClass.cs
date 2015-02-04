using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class AllWeaponsClass
    {
        private AllWeaponsReader _reader;
        private AllWeaponsContainer _container;

        public AllWeaponsClass(string fname)
        {
            _container = new AllWeaponsContainer();
            _reader = new AllWeaponsReader(fname, _container);
        }

        public void ReadAll()
        {
            _reader.ReadAll();
        }

        public void WriteAll()
        {

        }

        public AllWeapons Read(string key)
        {
            return _container.Find(o => o.Name == key);
            
        }

        public bool Write(string key)
        {
            return false;
        }

        public IEnumerable<AllWeapons> GetEnumerable()
        {
            return _container.AsEnumerable<AllWeapons>();
        }
    }
}
