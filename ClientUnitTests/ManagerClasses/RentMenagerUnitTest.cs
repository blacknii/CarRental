using CarRental.ClientClasses;
using CarRental.ManagerClasses;
using CarRental.RentClasses;
using CarRental.ReposytoriesClasses;
using CarRental.VehicleClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static ConsoleApp1.Units;

namespace RentManagerUnitTests
{
    [TestClass]
    public class RentManagerUnitTest
    {
        [TestMethod]
        public void RentVehicle()
        {
            // Arrange
            Address a1 = new Address("Perichora", "23");
            Client c1 = new Client("Adam", "Mickiewicz", "66071089838", a1, ClientType.Normal, 3);
            Vehicle v1 = new Bicycle("B001", 50);

            RentsRepository rr = new RentsRepository();
            ClientRepository rc = new ClientRepository();
            RentMenager rm = new RentMenager(rr, rc);

            // Act
            rm.rentVehicle(c1, v1, DateTime.Now.AddDays(-10));

            // Assert
            Assert.AreEqual(rr.getAll().Count, 1, "Vehicle was not successfully rented.");
        }

        [TestMethod]
        public void ReturnVehicle()
        {
            // Arrange
            Address a1 = new Address("Perichora", "23");
            Client c1 = new Client("Adam", "Mickiewicz", "66071089838", a1, ClientType.Normal, 3);
            Vehicle v1 = new Bicycle("B001", 50);

            RentsRepository rr = new RentsRepository();
            ClientRepository rc = new ClientRepository();
            RentMenager rm = new RentMenager(rr, rc);

            rm.rentVehicle(c1, v1, DateTime.Now.AddDays(-10));

            // Act
            rm.returnVehicle(v1);

            // Assert
            Assert.AreEqual(rr.getAll().Count, 0, "Vehicle was not successfully rented.");
            Assert.AreEqual(rr.getAllArchive().Count, 1, "Vehicle was not successfully rented.");
        }

        [TestMethod]
        public void ClientRentBalance()
        {
            // Arrange
            Address a1 = new Address("Perichora", "23");
            Client c1 = new Client("Adam", "Mickiewicz", "66071089838", a1, ClientType.Normal, 3);
            Vehicle v1 = new Bicycle("B001", 50);
            Vehicle v2 = new Bicycle("B002", 100);

            RentsRepository rr = new RentsRepository();
            ClientRepository rc = new ClientRepository();
            RentMenager rm = new RentMenager(rr, rc);

            rm.rentVehicle(c1, v1, DateTime.Now.AddDays(-10));
            rm.rentVehicle(c1, v2, DateTime.Now.AddDays(-15));

            rm.returnVehicle(v1);
            rm.returnVehicle(v2);
            Rent r1 = rr.getAllArchive().First(rent => rent.getVehicle() == v1);
            Rent r2 = rr.getAllArchive().First(rent => rent.getVehicle() == v2);

            int expectedBalance = r1.getRentCost() + r2.getRentCost();

            // Act
            int actualBalance = rm.checkClientRentBallance(c1);

            // Assert
            Assert.AreEqual(expectedBalance, actualBalance, "Rent balance calculation is incorrect.");
        }

    }
}
