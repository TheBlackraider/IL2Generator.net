using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2Generator
{
    public class AllNationsClass
    {
        private AllNationsReader _reader;
        private AllNationsContainer _container;

        public AllNationsClass(string fname)
        {
            _container = new AllNationsContainer();
            _reader = new AllNationsReader(fname, _container);
        }

        public void ReadAll()
        {
            _reader.ReadAll();
        }

        public void WriteAll()
        {

        }

        public AllNations Read(string key)
        {
            return _container.Find(o => o.Nation == key);

        }

        public bool Write(string key)
        {
            return false;
        }

        public IEnumerable<AllNations> GetEnumerable()
        {
            return _container.AsEnumerable<AllNations>();
        }
    }
}
