using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmLibrary
{
    public class Contact
    {
        private DateTime _beginDt;
        private string _dataInfo;
        private string _descr;
        private DateTime _endDt;
        private ContType _type;

        public Contact(DateTime beginDt, string dataInfo, ContType type)
        {
            BeginDt = beginDt;
            DataInfo = dataInfo;
            Type = type;
        }

        public Contact()
        {

        }

        public DateTime BeginDt
        {
            get { return _beginDt; }
            set { _beginDt = value; }
        }

        public DateTime EndDt
        {
            get { return _endDt; }
            set { _endDt = value; }
        }

        public string DataInfo
        {
            get { return _dataInfo; }
            set { _dataInfo = value; }
        }

        public string Description
        {
            get { return _descr; }
            set { _descr = value; }
        }

        public ContType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public Contact Clone()
        {
            return (Contact)MemberwiseClone();
        }

        public static bool operator==(Contact contact1, Contact contact2)
        {
            return contact1.BeginDt == contact2.BeginDt && contact1.DataInfo == contact2.DataInfo &&
                contact1.Description == contact2.Description && contact1.EndDt == contact2.EndDt &&
                contact1.Type == contact2.Type;
        }

        public static bool operator !=(Contact contact1, Contact contact2)
        {
            return !(contact1 == contact2);
        }
    }
}
