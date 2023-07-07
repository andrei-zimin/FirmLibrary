using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmLibrary
{
    public class SbFirmType
    {
        private bool _isMain;
        private string _name;

        public bool IsMain
        {
            get { return _isMain; }
            set { _isMain = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
