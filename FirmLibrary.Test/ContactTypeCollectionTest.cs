using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmLibrary.Test
{
    [TestClass]
    public class ContactTypeCollectionTest
    {
        ContactTypeCollection collection;

        [TestInitialize]
        public void Initialize()
        {
            collection = new ContactTypeCollection();
        }
        [TestMethod]
        public void AddContactTypeCollectionTest()
        {
            ContType contType = new ContType("Контакт");
            collection.Add(contType);

            int expected = 1;
            int actual = collection.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClearContactTypeCollectionTest()
        {
            ContType contType = new ContType("Контакт");
            collection.Add(contType);

            int expected = 0;

            collection.Clear();

            int actual = collection.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClearTwoContactTypeCollectionTest()
        {
            ContType contType1 = new ContType("Контакт1");
            ContType contType2 = new ContType("Контакт2");
            collection.Add(contType1);
            collection.Add(contType2);

            int expected = 0;

            collection.Clear();

            int actual = collection.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}

