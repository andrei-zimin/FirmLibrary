using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmLibrary
{
    public class SbFirmTypeCollection : IEnumerator<SbFirmType>
    {
        private List<SbFirmType> _lst = new List<SbFirmType>();
        private int index = -1;

        public int Count
        {
            get { return _lst.Count; }
        }

        public void Add(SbFirmType type)
        {
            _lst.Add(type);
        }

        public SbFirmTypeCollection()
        {
        }

        public SbFirmType Current => _lst[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            index++;
            if (index < _lst.Count)
                return true;
            else
                return false;
        }

        public void Reset()
        {
            index = -1;
        }

        public IEnumerator<SbFirmType> GetEnumerator()
        {
            return this;
        }
    }
}
