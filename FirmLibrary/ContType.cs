using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmLibrary
{
    public class ContType
    {
        private string _name;
        private string _note;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        public ContType(string name)
        {
            Name = name;
        }

        public static bool operator ==(ContType contType1, ContType contType2)
        {
            return contType1.Name == contType2.Name && contType1.Note == contType2.Note;
        }

        public static bool operator !=(ContType contType1, ContType contType2)
        {
            return !(contType1 == contType2);
        }
    }
}
