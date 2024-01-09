using CarRental.VehicleClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace VehicleUnitTests
{
    [TestClass]
    public class MopedUnitTest
    {
        [TestMethod]
        public void BasicGetters()
        {
            // Arrange
            Moped v1 = new Moped("134", 600, 800);
            Moped v2 = new Moped("133", 350, 1500);
            Moped v3 = new Moped("189", 4000, 4000);

            // Act
            string v1ExpectedValue = "Type: Moped, ID: 134, Price: 600, Engine displacement: 800";
            string v2ExpectedValue = "Type: Moped, ID: 133, Price: 437, Engine displacement: 1500";
            string v3ExpectedValue = "Type: Moped, ID: 189, Price: 6000, Engine displacement: 4000";

            // Assert
            Assert.AreEqual(v1.getVehicleInfo(), v1ExpectedValue, "getVehicleInfo() doesn't work correctly");
            Assert.AreEqual(v2.getVehicleInfo(), v2ExpectedValue, "getVehicleInfo() doesn't work correctly");
            Assert.AreEqual(v3.getVehicleInfo(), v3ExpectedValue, "getVehicleInfo() doesn't work correctly");
        }

        [TestMethod]
        public void BasicSetters()
        {
            // Arrange
            Moped v1 = new Moped("134", 600, 800);

            // Act
            string c1IdExpectedValue = "166";
            int c1BaseRentPriceExpectedValue = 400;
            int c1EngineDisplacementExpectedValue = 200;

            v1.setId(c1IdExpectedValue);
            v1.setBaseRentPrice(c1BaseRentPriceExpectedValue);
            v1.setEngineDisplacement(c1EngineDisplacementExpectedValue);

            // Assert
            Assert.AreEqual(v1.getId(), c1IdExpectedValue, "getId() doesn't work correctly");
            Assert.AreEqual(v1.getBaseRentPrice(), c1BaseRentPriceExpectedValue, "getBaseRentPrice() doesn't work correctly");
            Assert.AreEqual(v1.getEngineDisplacement(), c1EngineDisplacementExpectedValue, "getEngineDisplacement() doesn't work correctly");
        }

        [TestMethod]
        public void PriceCalculations()
        {
            // Arrange
            Moped v1 = new Moped("134", 600, 800);
            Moped v2 = new Moped("133", 350, 1500);
            Moped v3 = new Moped("189", 4000, 4000);

            // Act
            int v1BaseRentPriceExpectedValue = 600;
            int v1ActualRentalPriceExpectedValue = 600;

            int v2BaseRentPriceExpectedValue = 350;
            int v2ActualRentalPriceExpectedValue = 437;

            int v3BaseRentPriceExpectedValue = 4000;
            int v3ActualRentalPriceExpectedValue = 6000;

            // Assert
            Assert.AreEqual(v1.getBaseRentPrice(), v1BaseRentPriceExpectedValue, "getBaseRentPrice() doesn't work correctly");
            Assert.AreEqual(v1.getActualRentalPrice(), v1ActualRentalPriceExpectedValue, "getActualRentalPrice() doesn't work correctly");

            Assert.AreEqual(v2.getBaseRentPrice(), v2BaseRentPriceExpectedValue, "getBaseRentPrice() doesn't work correctly");
            Assert.AreEqual(v2.getActualRentalPrice(), v2ActualRentalPriceExpectedValue, "getActualRentalPrice() doesn't work correctly");

            Assert.AreEqual(v3.getBaseRentPrice(), v3BaseRentPriceExpectedValue, "getBaseRentPrice() doesn't work correctly");
            Assert.AreEqual(v3.getActualRentalPrice(), v3ActualRentalPriceExpectedValue, "getActualRentalPrice() doesn't work correctly");
        }
    }
}
