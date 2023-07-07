using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmLibrary
{
    public class FirmFactory
    {
        private List<string> ids = new List<string>() { "Field1", "Field2", "Field3", "Field4", "Field5" };

        public FirmFactory(List<string> ids)
        {
            this.ids = ids;
        }

        public FirmFactory()
        {

        }

        public Firm Create(string name, SbFirmType type)
        {
            Firm firm = new Firm(name, type);
            for (int i = 0; i < ids.Count; i++)
            {
                firm.AddField(ids[i], null);
            }

            return firm;
        }
    }
}
