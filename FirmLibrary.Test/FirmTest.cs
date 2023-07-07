using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmLibrary.Test
{
    [TestClass]
    public class FirmTest
    {
        Firm firm;
        SbFirmType sbFirmType = new SbFirmType();

        [TestInitialize]
        public void Initialize()
        {
            sbFirmType.IsMain = true;
            firm = new Firm("Nike", sbFirmType);
        }

        [TestMethod]
        public void ConstructorCountSubFirmTest()
        {
            int expected = 1;

            int actual = firm.SbFirmsCount;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddFieldTest()
        {
            int expected = 100;
            string nameField = "CountEmployee";

            firm.AddField(nameField, expected);
            int actual = (int)firm.GetField(nameField);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddRepeatNameFieldTest()
        {
            string nameField = "CountEmployee";

            firm.AddField(nameField, 100);
            firm.AddField(nameField, 80);
        }

        [TestMethod]
        public void SetFieldTest()
        {
            int expected = 70;
            string nameField = "CountEmployee";

            firm.AddField(nameField, 100);
            firm.SetField(nameField, 70);

            int actual = (int)firm.GetField(nameField);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetMissingFieldTest()
        {
            string nameField = "CountEmployee";
            firm.AddField(nameField, 100);
            firm.SetField("year", 70);
        }

        [TestMethod]
        public void RenameFieldTest()
        {
            int expected = 100;
            string oldNameField = "CountEmployee";
            string newNameField = "Employee";
            firm.AddField(oldNameField, expected);
            firm.RenameField(oldNameField, newNameField);

            int actual = (int)firm.GetField(newNameField);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RenameFieldTestAndGetOldField()
        {
            int expected = 100;
            string oldNameField = "CountEmployee";
            string newNameField = "Employee";
            firm.AddField(oldNameField, expected);
            firm.RenameField(oldNameField, newNameField);

            firm.GetField(oldNameField);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RenameFieldTestAndSameName()
        {
            int expected = 100;
            string oldNameField = "CountEmployee";
            string newNameField = "Employee";

            firm.AddField(oldNameField, expected);
            firm.AddField(newNameField, expected);
            firm.RenameField(newNameField, oldNameField);
        }
        [TestMethod]
        public void AddContactOneSbFirm()
        {
            Contact contact = CreateContact();
            firm.AddContact(contact);
            Contact expected = CreateContact();

            Assert.IsTrue(firm.ExistContact(expected));

        }

        private Contact CreateContact()
        {
            ContType contype = new ContType("Cont");
            Contact contact = new Contact(new DateTime(2020, 11, 03), "info", contype);
            return contact;
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddContactTwoSbFirm()
        {
            Contact contact = CreateContact();
            SubFirm subfirm = new SubFirm("Дочернее подразделение");
            firm.AddSbFirm(subfirm);
            firm.AddContact(contact);
        }


        [TestMethod]
        public void AddContactSbFirmExists()
        {
            Contact contact = CreateContact();
            SubFirm subFirm = new SubFirm("Подразделение");
            firm.AddSbFirm(subFirm);
            Assert.IsTrue(firm.AddContactToSbFirm(contact, "Подразделение"));            
            Assert.IsTrue(firm.ExistContact(contact));
        }

        [TestMethod]
        public void AddContactToSubFirmTest()
        {
            Contact contact = CreateContact();
            SubFirm subFirm = new SubFirm("Подразделение");
            firm.AddSbFirm(subFirm);
            Assert.IsFalse(firm.AddContactToSbFirm(contact, "Отдел"));
        }

        [TestMethod]
        public void ValuesUserFieldsTest()
        {         
            List<string> ids = new List<string>() { "Field1", "Field2", "Field3", "Field4", "Field5" };

            FirmFactory firmFactory = new FirmFactory(ids);

            Firm firm = firmFactory.Create("PRO", sbFirmType);

            
            for (int i = 0; i <ids.Count; i++)
            {
                Assert.IsTrue(firm.ContainsField(ids[i]));
            }

            SubFirm subFirm = firm.FindSubFirm("Основное подразделение");
            Assert.IsNotNull(subFirm);
            Assert.IsTrue(subFirm.IsMain);
        }
    }
}