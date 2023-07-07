using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirmLibrary.Test
{
    [TestClass]
    public class SbFirmTypeCollectionTest
    {
        private SbFirmType firmType1;
        private SbFirmType firmType2;
        private SbFirmType firmType3;
        private SbFirmTypeCollection typeCollection;

        [TestInitialize]
        public void Initialize()
        {
            firmType1 = new SbFirmType() { Name = "Type1" };
            firmType2 = new SbFirmType() { Name = "Type2" };
            firmType3 = new SbFirmType() { Name = "Type3" };

            typeCollection = new SbFirmTypeCollection();
        }

        [TestMethod]
        public void AddTest()
        {
            int expectedCount = 3;

            typeCollection.Add(firmType1);
            typeCollection.Add(firmType2);
            typeCollection.Add(firmType3);

            int actualCount = typeCollection.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void IEnumeratorTest()
        {
            int expectedCount = 3;

            typeCollection.Add(firmType1);
            typeCollection.Add(firmType2);
            typeCollection.Add(firmType3);

            int i = 0;
            SbFirmType[] firmTypes = { firmType1, firmType2, firmType3 };

            foreach (var type in typeCollection)
            {
                Assert.AreEqual(type.Name, firmTypes[i].Name);
                i++;
            }

            Assert.AreEqual(expectedCount, i);
        }
    }
}
