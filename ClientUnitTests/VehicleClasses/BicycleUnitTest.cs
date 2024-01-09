using CarRental.ClientClasses;
using CarRental.VehicleClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ConsoleApp1.Units;

namespace VehicleUnitTests
{
    [TestClass]
    public class BicycleUnitTest
    {
        [TestMethod]
        public void BasicGetters()
        {
            // Arrange
            Bicycle v1 = new Bicycle("44", 100);
            Bicycle v2 = new Bicycle("12", 40);
            Bicycle v3 = new Bicycle("107", 3200);

            // Act
            string v1ExpectedValue = "Type: Bike, ID: 44, Price: 100";
            string v2ExpectedValue = "Type: Bike, ID: 12, Price: 40";
            string v3ExpectedValue = "Type: Bike, ID: 107, Price: 3200";


            // Assert
            Assert.AreEqual(v1.getVehicleInfo(), v1ExpectedValue, "getVehicleInfo() doesn't work correctly");
            Assert.AreEqual(v2.getVehicleInfo(), v2ExpectedValue, "getVehicleInfo() doesn't work correctly");
            Assert.AreEqual(v3.getVehicleInfo(), v3ExpectedValue, "getVehicleInfo() doesn't work correctly");
        }

        [TestMethod]
        public void BasicSetters()
        {
            // Arrange
            Bicycle v1 = new Bicycle("44", 100);

            // Act
            string c1IdExpectedValue = "66";
            int c1BaseRentPriceExpectedValue = 220;

            v1.setId(c1IdExpectedValue);
            v1.setBaseRentPrice(c1BaseRentPriceExpectedValue);

            // Assert
            Assert.AreEqual(v1.getId(), c1IdExpectedValue, "getId() doesn't work correctly");
            Assert.AreEqual(v1.getBaseRentPrice(), c1BaseRentPriceExpectedValue, "getBaseRentPrice() doesn't work correctly");
        }

        [TestMethod]
        public void PriceCalculations()
        {
            // Arrange
            Bicycle v1 = new Bicycle("44", 100);

            // Act
            int v1BaseRentPriceExpectedValue = 100;
            int v1ActualRentalPriceExpectedValue = 100;

            // Assert
            Assert.AreEqual(v1.getBaseRentPrice(), v1BaseRentPriceExpectedValue, "getBaseRentPrice() doesn't work correctly");
            Assert.AreEqual(v1.getActualRentalPrice(), v1ActualRentalPriceExpectedValue, "getActualRentalPrice() doesn't work correctly");
        }
    }
}
