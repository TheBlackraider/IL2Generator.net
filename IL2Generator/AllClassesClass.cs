using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class AllClassesClass
    {
        private AllClassesReader _reader;
        private AllClassesContainer _container;
        //private AllClasses theClass;

        public AllClassesClass(string fname)
        {
            _container = new AllClassesContainer();
            _reader = new AllClassesReader(fname, _container);
        }

        public void ReadAll()
        {
            _reader.ReadAll();
        }

        public void WriteAll()
        {

        }

        public AllClasses Read(string key)
        {
            return _container.Find(o => o.PlaneName == key);
            
        }

        public bool Write(string key)
        {
            return false;
        }

        public IEnumerable<AllClasses> GetEnumerable()
        {
            return _container.AsEnumerable<AllClasses>();
        }
    }
}
