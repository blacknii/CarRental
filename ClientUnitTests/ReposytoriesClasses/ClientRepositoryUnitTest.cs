using CarRental.ClientClasses;
using CarRental.ReposytoriesClasses;
using CarRental.VehicleClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static ConsoleApp1.Units;

namespace RepositoryUnitTests
{
    [TestClass]
    public class ClientRepositoryUnitTest
    {
        [TestMethod]
        public void BasicFunctionality()
        {
            // Arrange
            Address a1 = new Address("Perichora", "23");
            Address a2 = new Address("Bema", "12");
            Address a3 = new Address("Sienna", "23");

            Client c1 = new Client("Adam", "Mickiewicz", "66071089838", a1, ClientType.Normal, 3);
            Client c2 = new Client("Tomasz", "Mickiewicz", "51012413685", a2, ClientType.Vip, 6);
            Client c3 = new Client("Adam", "Małysz", "49081079686", a3, ClientType.SuperVip, 10);

            ClientRepository cr1 = new ClientRepository();

            // Act
            cr1.create(c1);
            cr1.create(c2);
            cr1.create(c3);

            List<Client> cr1ExpectedValue = new List<Client> { c1, c2, c3 };

            // Assert
            CollectionAssert.AreEqual(cr1.getAll(), cr1ExpectedValue, "getAll() or create() doesn't work correctly");

            // Act
            cr1.remove(c1);
            cr1.delete(c2);

            List<Client> cr1ExpectedValue2 = new List<Client> { c3 };

            // Assert
            CollectionAssert.AreEqual(cr1.getAll(), cr1ExpectedValue2, "getAll(), remove() or delete() doesn't work correctly");

            // Act
            cr1.update(c3, c1);

            List<Client> cr1ExpectedValue3 = new List<Client> { c1 };

            // Assert
            CollectionAssert.AreEqual(cr1.getAll(), cr1ExpectedValue3, "getAll() or update() doesn't work correctly");

            // Act and Assert
            Assert.AreEqual(cr1.find(c1), 0, "getAll() or find() doesn't work correctly");
        }
    }
}
