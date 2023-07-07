using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmLibrary
{
    public class SubFirm
    {
        private string _bossName;
        private List<Contact> _contacts = new List<Contact>();
        private string _email;
        private string _name;
        private string _ofsBossName;
        private string _tel;
        private SbFirmType _type;

        public SubFirm(string name)
        {
            Name = name;
        }

        public string BossName
        {
            get { return _bossName; }
            set { _bossName = value; }
        }

        public int CountContacts
        {
            get { return _contacts.Count; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public bool IsMain
        {
            get
            {
                if (_type != null)
                    return _type.IsMain;
                return false;
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string OfsBossName
        {
            get { return _ofsBossName; }
            set { _ofsBossName = value; }
        }

        public SbFirmType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        public void AddContact(Contact contact)
        {
            if (!ExistContact(contact))
                _contacts.Add(contact);
        }

        public bool ExistContact(Contact contact)
        {
            return _contacts.Any(t => t == contact);
        }

        public bool IsYourType(ContType type)
        {
            return _type != null && _type.Name == type.Name;
        }
    }
}
