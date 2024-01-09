using CarRental.ClientClasses;
using CarRental.RentClasses;
using CarRental.VehicleClasses;
using ConsoleApp1;
using ConsoleApp1.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RentUnitTests
{
    [TestClass]
    public class RentUnitTest
    {
        [TestMethod]
        public void BasicSetters()
        {
            // Arrange
            Address clientAddress = new Address("Sample Street", "10");
            Client client = new Client("John", "Doe", "12345678901", clientAddress, Units.ClientType.Normal, 2);
            Vehicle vehicle = new Bicycle("B001", 50);
            DateTime rentStartDateTime = new DateTime(2024, 1, 1);
            Rent rent = new Rent(client, vehicle, rentStartDateTime);

            Client newClient = new Client("Jane", "Smith", "10987654321", clientAddress, Units.ClientType.Vip, 3);
            Vehicle newVehicle = new Bicycle("B002", 100);
            DateTime newRentStartDateTime = new DateTime(2024, 2, 1);

            // Act
            rent.setClient(newClient);
            rent.setVehicle(newVehicle);
            rent.setRentStartDateTime(newRentStartDateTime);

            // Assert
            Assert.AreEqual(newClient, rent.getClient(), "setClient() does not set the expected client.");
            Assert.AreEqual(newVehicle, rent.getVehicle(), "setVehicle() does not set the expected vehicle.");
            Assert.AreEqual(newRentStartDateTime, rent.getRentStartDateTime(), "setRentStartDateTime() does not set the expected start date.");
        }

        [TestMethod]
        public void PriceCalculations()
        {
            // Arrange
            Address clientAddress = new Address("Sample Street", "10");
            Client client = new Client("John", "Doe", "12345678901", clientAddress, Units.ClientType.Normal, 2);
            Vehicle vehicle = new Bicycle("B001", 50);  
            DateTime rentStartDateTime = new DateTime(2024, 1, 1);
            DateTime rentEndDateTime = new DateTime(2024, 1, 4);  

            Rent rent = new Rent(client, vehicle, rentStartDateTime);
            rent.returnVehicle(rentEndDateTime);

            int expectedCost = 200; 

            // Act
            int actualCost = rent.getRentCost();

            // Assert
            Assert.AreEqual(expectedCost, actualCost, "getRentCost() does not calculate the expected cost.");
        }

        [TestMethod]
        public void RentInfoMethods()
        {
            // Arrange
            Address clientAddress = new Address("Sample Street", "10");
            Client client = new Client("John", "Doe", "12345678901", clientAddress, Units.ClientType.Normal, 2);
            Vehicle vehicle = new Bicycle("B001", 50);
            DateTime rentStartDateTime = new DateTime(2024, 1, 1);
            DateTime rentEndDateTime = new DateTime(2024, 1, 3);

            Rent rent = new Rent(client, vehicle, rentStartDateTime);
            rent.returnVehicle(rentEndDateTime);

            // Act
            string expectedIdInfo = "Rent id: " + rent.id;
            string expectedRentClientInfo = "John Doe";
            string expectedRentVehicleInfo = "Type: Bike, ID: B001, Price: 50";
            string expectedRentStartDateTimeInfo = "Rent start date: " + rentStartDateTime;
            string expectedRentEndDateTimeInfo = "Rent end date: " + rentEndDateTime;
            string expectedRentDurationInfo = "Rent duration: 3";
            string expectedRentCostInfo = "Rent cost: 150";
            string expectedRentInfo = expectedIdInfo + "\n" + expectedRentStartDateTimeInfo + "\n" + expectedRentCostInfo + "\n" + expectedRentClientInfo + "\n" + expectedRentVehicleInfo;

            // Assert
            Assert.AreEqual(expectedIdInfo, rent.getIdInfo(), "getIdInfo() does not return correct id info.");
            Assert.AreEqual(expectedRentClientInfo, rent.getRentClientInfo(), "getRentClientInfo() does not return correct client info.");
            Assert.AreEqual(expectedRentVehicleInfo, rent.getRentVehicleInfo(), "getRentVehicleInfo() does not return correct vehicle info.");
            Assert.AreEqual(expectedRentStartDateTimeInfo, rent.getRentStartDateTimeInfo(), "getRentStartDateTimeInfo() does not return correct start date info.");
            Assert.AreEqual(expectedRentEndDateTimeInfo, rent.getRentEndDateTimeInfo(), "getRentEndDateTimeInfo() does not return correct end date info.");
            Assert.AreEqual(expectedRentDurationInfo, rent.getRentDurationInfo(), "getRentDurationInfo() does not return correct duration info.");
            Assert.AreEqual(expectedRentCostInfo, rent.getRentCostInfo(), "getRentCostInfo() does not return correct cost info.");
            Assert.AreEqual(expectedRentInfo, rent.getRentInfo(), "getRentInfo() does not return correct rent info.");
        }

        [TestMethod]
        public void Exceptions()
        {
            // Arrange
            Address clientAddress = new Address("Sample Street", "10");
            Client client = new Client("John", "Doe", "12345678901", clientAddress, Units.ClientType.Normal, 2);
            Vehicle vehicle = new Bicycle("B001", 50);
            DateTime rentStartDateTime = new DateTime(2010, 1, 1);

            // Act and Assert
            Assert.ThrowsException<RentException>(() => new Rent(null, vehicle, rentStartDateTime), "Exception not thrown for null client.");
            Assert.ThrowsException<RentException>(() => new Rent(client, null, rentStartDateTime), "Exception not thrown for null vehicle.");
            Assert.ThrowsException<RentException>(() => new Rent(client, vehicle, rentStartDateTime), "Exception not thrown for invalid start date.");
        }

    }
}
