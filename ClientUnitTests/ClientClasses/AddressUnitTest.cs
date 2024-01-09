using CarRental.ClientClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;

namespace AddressUnitTests
{
    [TestClass]
    public class AddressUnitTest
    {
        [TestMethod]
        public void BasicGetters()
        {
            // Arrange
            Address a1 = new Address("Perichora", "23");
            Address a2 = new Address("Bema", "12");
            Address a3 = new Address("Sienna", "23");

            // Act
            string a1ExpectedValue = "Address: Perichora 23";
            string a2ExpectedValue = "Address: Bema 12";
            string a3ExpectedValue = "Address: Sienna 23";

            // Assert
            Assert.AreEqual(a1.getAddressInfo(), a1ExpectedValue, "getAddressInfo() doesn't work correctly");
            Assert.AreEqual(a2.getAddressInfo(), a2ExpectedValue, "getAddressInfo() doesn't work correctly");
            Assert.AreEqual(a3.getAddressInfo(), a3ExpectedValue, "getAddressInfo() doesn't work correctly");
        }

    }
}
