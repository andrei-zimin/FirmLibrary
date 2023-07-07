using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmLibrary.Test
{
    [TestClass]
    public class ContactTest
    {
        [TestMethod]
        public void ContactCloneTest()
        {
            ContType contype = new ContType("Cont");
            Contact contact = new Contact(new DateTime(2020, 11, 03), "info", contype);
            contact.Description = "desciption";
            contact.EndDt = new DateTime(2020, 11, 11);

            Contact clone = contact.Clone();

            Assert.AreEqual(contact.BeginDt, clone.BeginDt);
            Assert.AreEqual(contact.DataInfo, clone.DataInfo);
            Assert.AreEqual(contact.Description, clone.Description);
            Assert.AreEqual(contact.EndDt, clone.EndDt);
            Assert.AreEqual(contact.Type, clone.Type);
        }
    }
}
