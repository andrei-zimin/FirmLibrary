using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmLibrary
{
    public class Firm
    {
        private string _country;
        private DateTime _dateln;
        private string _email;
        private string _name;
        private int _postInx;
        private string _region;
        private List<SubFirm> _sbFirms = new List<SubFirm>();
        private string _street;
        private string _town;
        private Dictionary<string, object> _usrFields = new Dictionary<string, object>();
        private string _web;
        private SbFirmType _type;

        public Firm(string name, SbFirmType type)
        {
            Name = name;
            _type = type;

            SubFirm mainSubFirm = new SubFirm("Основное подразделение");
            mainSubFirm.Type = type;
            _sbFirms.Add(mainSubFirm);
        }

        public SbFirmType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public DateTime Dateln
        {
            get { return _dateln; }
            set { _dateln = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int PostInx
        {
            get { return _postInx; }
            set { _postInx = value; }
        }

        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        public int SbFirmsCount
        {
            get { return _sbFirms.Count; }
        }

        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        public string Town
        {
            get { return _town; }
            set { _town = value; }
        }

        public string Web
        {
            get { return _web; }
            set { _web = value; }
        }

        public int CountUserFields
        {
            get
            {
                return _usrFields.Count;
            }
        }

        public void AddField(string name, object value)
        {
            if (!_usrFields.ContainsKey(name))
                _usrFields.Add(name, value);
            else
                throw new ArgumentException("Уже есть поле с таким названием");
        }

        public void SetField(string name, object value)
        {
            if (!_usrFields.ContainsKey(name))
                throw new ArgumentException("Нет поля с таким названием");
            _usrFields[name] = value;
        }

        public object GetField(string name)
        {
            if (!_usrFields.ContainsKey(name))
                throw new ArgumentException("Нет поля с таким названием");
            return _usrFields[name];
        }

        public bool ContainsField (string name)
        {
            if (_usrFields.ContainsKey(name))
                return true;
            else
                return false;
        }
        public void RenameField(string oldName, string newName)
        {
            if (!_usrFields.ContainsKey(oldName))
                throw new ArgumentException("Нет поля с таким названием");
            if (_usrFields.ContainsKey(newName))
                throw new ArgumentException("Нельзя переименовать так как уже есть поле с таким названием");

            object val = _usrFields[oldName];
            _usrFields.Remove(oldName);
            _usrFields.Add(newName, val);
        }

        public List<SubFirm> GetMainSubfirms()
        {
            return _sbFirms.Where(t => t.IsMain).ToList();
        }

        public bool ExistContact(Contact contact)
        {
           return _sbFirms.Any(t => t.ExistContact(contact));
        }

        public void AddSbFirm(SubFirm subFirm)
        {

            _sbFirms.Add(subFirm);
        }

        public bool AddContactToSbFirm(Contact contact, string nameSubFirm)
        {
            SubFirm subFirm = _sbFirms.FirstOrDefault(t => t.Name == nameSubFirm);
            if (subFirm != null)
            {
                subFirm.AddContact(contact);
                return true;
            }
            return false;
        }

        public void AddContact(Contact contact)
        {
            if (_sbFirms.Count > 1)
                throw new Exception("В данной фирме есть несколько подфирм, задайте какой подфирме добавить контакт");
            
            _sbFirms[0].AddContact(contact);
        }

        public SubFirm FindSubFirm(string name)
        {

            return _sbFirms.FirstOrDefault(t => t.Name == name);
        }
    }
}
