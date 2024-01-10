using CarRental.ClientClasses;
using CarRental.ReposytoriesClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ConsoleApp1.Units;
using System.Collections.Generic;
using CarRental.VehicleClasses;
using ConsoleApp1;
using CarRental.RentClasses;

namespace RepositoryUnitTests
{
    [TestClass]
    public class RentsRepositoryUnitTest
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

            Car v1 = new Car("234", 600, 900, Units.Segment.A);
            Car v2 = new Car("233", 350, 1600, Units.Segment.C);
            Car v3 = new Car("289", 4000, 5000, Units.Segment.E);

            Rent r1 = new Rent(c1, v1, DateTime.Now.AddDays(-10));
            Rent r2 = new Rent(c2, v2, DateTime.Now.AddDays(-20));
            Rent r3 = new Rent(c3, v3, DateTime.Now.AddDays(-30));

            RentsRepository rr1 = new RentsRepository();

            // Act
            rr1.create(r1);
            rr1.create(r2);
            rr1.create(r3);

            List<Rent> rr1ExpectedValue = new List<Rent> { r1, r2, r3 };

            // Assert
            CollectionAssert.AreEqual(rr1.getAll(), rr1ExpectedValue, "getAll() or create() doesn't work correctly");

            // Act
            rr1.remove(r1);
            rr1.delete(r2);

            List<Rent> rr1ExpectedValue2 = new List<Rent> { r3 };

            // Assert
            CollectionAssert.AreEqual(rr1.getAll(), rr1ExpectedValue2, "getAll(), remove() or delete() doesn't work correctly");

            // Act
            rr1.update(r3, r1);

            List<Rent> vr1ExpectedValue3 = new List<Rent> { r1 };

            // Assert
            CollectionAssert.AreEqual(rr1.getAll(), vr1ExpectedValue3, "getAll() or update() doesn't work correctly");

            // Act and Assert
            Assert.AreEqual(rr1.find(r1), 0, "getAll() or find() doesn't work correctly");
        }

        [TestMethod]
        public void ArchiveFunctionality()
        {
            // Arrange
            Address a1 = new Address("Perichora", "23");
            Address a2 = new Address("Bema", "12");
            Address a3 = new Address("Sienna", "23");

            Client c1 = new Client("Adam", "Mickiewicz", "66071089838", a1, ClientType.Normal, 3);
            Client c2 = new Client("Tomasz", "Mickiewicz", "51012413685", a2, ClientType.Vip, 6);
            Client c3 = new Client("Adam", "Małysz", "49081079686", a3, ClientType.SuperVip, 10);

            Car v1 = new Car("234", 600, 900, Units.Segment.A);
            Car v2 = new Car("233", 350, 1600, Units.Segment.C);
            Car v3 = new Car("289", 4000, 5000, Units.Segment.E);

            Rent r1 = new Rent(c1, v1, DateTime.Now.AddDays(-10));
            Rent r2 = new Rent(c2, v2, DateTime.Now.AddDays(-20));
            Rent r3 = new Rent(c3, v3, DateTime.Now.AddDays(-30));

            RentsRepository rr1 = new RentsRepository();

            // Act
            rr1.createArchive(r1);
            rr1.createArchive(r2);
            rr1.createArchive(r3);

            List<Rent> rr1ExpectedValue = new List<Rent> { r1, r2, r3 };

            // Assert
            CollectionAssert.AreEqual(rr1.getAllArchive(), rr1ExpectedValue, "getAll() or create() doesn't work correctly");

            // Act
            rr1.removeArchive(r1);
            rr1.deleteArchive(r2);

            List<Rent> rr1ExpectedValue2 = new List<Rent> { r3 };

            // Assert
            CollectionAssert.AreEqual(rr1.getAllArchive(), rr1ExpectedValue2, "getAll(), remove() or delete() doesn't work correctly");

            // Act
            rr1.updateArchive(r3, r1);

            List<Rent> vr1ExpectedValue3 = new List<Rent> { r1 };

            // Assert
            CollectionAssert.AreEqual(rr1.getAllArchive(), vr1ExpectedValue3, "getAll() or update() doesn't work correctly");

            // Act and Assert
            Assert.AreEqual(rr1.findArchive(r1), 0, "getAll() or find() doesn't work correctly");
        }
    }
}
