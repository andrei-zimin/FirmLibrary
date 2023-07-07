using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmLibrary
{
    public class ContactTypeCollection
    {
        private List<ContType> _lst = new List<ContType>();

        public int Count
        { 
            get { return _lst.Count; } 
        }

        public ContactTypeCollection()
        {
        }

        public void Add(ContType contType)
        {
            _lst.Add(contType);
        }

        public void Clear()
        {
            _lst.Clear();
        }
    }
}
