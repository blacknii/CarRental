using CarRental.ClientClasses;
using ConsoleApp1;
using ConsoleApp1.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ConsoleApp1.Units;

namespace ClientUnitTests.ClientClasses
{
    [TestClass]
    public class ClientUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            Address a1 = new Address("Perichora", "23");
            Address a2 = new Address("Bema", "12");
            Address a3 = new Address("Sienna", "23");

            Client c1 = new Client("Adam", "Mickiewicz", "66071089838", a1, ClientType.Normal, 3);
            Client c2 = new Client("Tomasz", "Mickiewicz", "51012413685", a2, ClientType.Vip, 6);
            Client c3 = new Client("Adam", "Małysz", "49081079686", a3, ClientType.SuperVip, 10);

            // Act
            string c1ExpectedValue = "Client: Adam Mickiewicz, PESEL: 66071089838, maxCarsCount: 3, clientType: Normal\nAddress: Perichora 23";
            string c2ExpectedValue = "Client: Tomasz Mickiewicz, PESEL: 51012413685, maxCarsCount: 6, clientType: Vip\nAddress: Bema 12";
            string c3ExpectedValue = "Client: Adam Małysz, PESEL: 49081079686, maxCarsCount: 10, clientType: SuperVip\nAddress: Sienna 23";


            // Assert
            Assert.AreEqual(c1.getClientInfo(), c1ExpectedValue, "getClientInfo() doesn't work correctly");
            Assert.AreEqual(c2.getClientInfo(), c2ExpectedValue, "getClientInfo() doesn't work correctly");
            Assert.AreEqual(c3.getClientInfo(), c3ExpectedValue, "getClientInfo() doesn't work correctly");
        }
        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            Address a1 = new Address("Perichora", "23");

            Client c1 = new Client("Adam", "Mickiewicz", "66071089838", a1, ClientType.Normal, 3);

            // Act
            string c1FirstNameExpectedValue = "Isaac";
            string c1LastNameExpectedValue = "Newton";
            string c1PersonalIDExpectedValue = "83112789526";
            Address c1AddressExpectedValue = new Address("Grzybowa", "38");
            ClientType c1ClientTypeExpectedValue = ClientType.Vip;
            int c1MaxCarsCountExpectedValue = 7;

            c1.setFirstName(c1FirstNameExpectedValue);
            c1.setLastName(c1LastNameExpectedValue);
            c1.setPersonalID(c1PersonalIDExpectedValue);
            c1.setAddress(c1AddressExpectedValue);
            c1.setClientType(c1ClientTypeExpectedValue);
            c1.setMaxCarsCount(c1MaxCarsCountExpectedValue);


            // Assert
            Assert.AreEqual(c1.getFirstName(), c1FirstNameExpectedValue, "getClientInfo() doesn't work correctly");
            Assert.AreEqual(c1.getLastName(), c1LastNameExpectedValue, "getClientInfo() doesn't work correctly");
            Assert.AreEqual(c1.getPersonalID(), c1PersonalIDExpectedValue, "getClientInfo() doesn't work correctly");
            Assert.AreEqual(c1.getAddress(), c1AddressExpectedValue, "getClientInfo() doesn't work correctly");
            Assert.AreEqual(c1.getClientType(), c1ClientTypeExpectedValue, "getClientInfo() doesn't work correctly");
            Assert.AreEqual(c1.getMaxCarsCount(), c1MaxCarsCountExpectedValue, "getClientInfo() doesn't work correctly");
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Arrange
            Address a1 = new Address("Perichora", "23");

            Client c1 = new Client("Adam", "Mickiewicz", "66071089838", a1, ClientType.Normal, 3);

            // Act
            string c1FirstNameExpectedErrorMessage = "First name cannot be empty.";
            string c1LastNameExpectedErrorMessage = "Last name cannot be null.";
            string c1PersonalIDExpectedErrorMessage = "Personal ID should have 11 characters.";
            string c1AddressExpectedErrorMessage = "Address cannot be null.";
            string c1MaxCarsCountExpectedErrorMessage = "Max cars count cannot be a negative number.";

            // Assert
            Assert.AreEqual(c1FirstNameExpectedErrorMessage, Assert.ThrowsException<ClientException>(() => c1.setFirstName("")).Message);
            Assert.AreEqual(c1LastNameExpectedErrorMessage, Assert.ThrowsException<ClientException>(() => c1.setLastName(null)).Message);
            Assert.AreEqual(c1PersonalIDExpectedErrorMessage, Assert.ThrowsException<ClientException>(() => c1.setPersonalID("123")).Message);
            Assert.AreEqual(c1AddressExpectedErrorMessage, Assert.ThrowsException<ClientException>(() => c1.setAddress(null)).Message);
            Assert.AreEqual(c1MaxCarsCountExpectedErrorMessage, Assert.ThrowsException<ClientException>(() => c1.setMaxCarsCount(-1)).Message);
        }

    }
}
