using CarRental.VehicleClasses;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace VehicleUnitTests
{
    [TestClass]
    public class CarUnitTest
    {
        [TestMethod]
        public void BasicGetters()
        {
            // Arrange
            Car v1 = new Car("234", 600, 900, Units.Segment.A);
            Car v2 = new Car("233", 350, 1600, Units.Segment.C);
            Car v3 = new Car("289", 4000, 5000, Units.Segment.E);

            // Act
            string v1ExpectedValue = "Type: Car, ID: 234, Price: 600, Engine displacement: 900, Segment: A";
            string v2ExpectedValue = "Type: Car, ID: 233, Price: 455, Engine displacement: 1600, Segment: C";
            string v3ExpectedValue = "Type: Car, ID: 289, Price: 6000, Engine displacement: 5000, Segment: E";

            // Assert
            Assert.AreEqual(v1.getVehicleInfo(), v1ExpectedValue, "getVehicleInfo() doesn't work correctly");
            Assert.AreEqual(v2.getVehicleInfo(), v2ExpectedValue, "getVehicleInfo() doesn't work correctly");
            Assert.AreEqual(v3.getVehicleInfo(), v3ExpectedValue, "getVehicleInfo() doesn't work correctly");
        }

        [TestMethod]
        public void BasicSetters()
        {
            // Arrange
            Car v1 = new Car("134", 600, 800, Units.Segment.A);

            // Act
            string c1IdExpectedValue = "166";
            int c1BaseRentPriceExpectedValue = 400;
            int c1EngineDisplacementExpectedValue = 200;
            Units.Segment c1SegmentExpectedValue = Units.Segment.B;

            v1.setId(c1IdExpectedValue);
            v1.setBaseRentPrice(c1BaseRentPriceExpectedValue);
            v1.setEngineDisplacement(c1EngineDisplacementExpectedValue);
            v1.setSegment(c1SegmentExpectedValue);

            // Assert
            Assert.AreEqual(v1.getId(), c1IdExpectedValue, "getId() doesn't work correctly");
            Assert.AreEqual(v1.getBaseRentPrice(), c1BaseRentPriceExpectedValue, "getBaseRentPrice() doesn't work correctly");
            Assert.AreEqual(v1.getEngineDisplacement(), c1EngineDisplacementExpectedValue, "getEngineDisplacement() doesn't work correctly");
            Assert.AreEqual(v1.getSegment(), c1SegmentExpectedValue, "getSegment() doesn't work correctly");
        }

        [TestMethod]
        public void PriceCalculations()
        {
            // Arrange
            Car v1 = new Car("234", 100, 1000, Units.Segment.A);
            Car v2 = new Car("233", 100, 1600, Units.Segment.C);
            Car v3 = new Car("289", 100, 8000, Units.Segment.E);

            // Act
            int v1BaseRentPriceExpectedValue = 100;
            int v1ActualRentalPriceExpectedValue = 100;

            int v2BaseRentPriceExpectedValue = 100;
            int v2ActualRentalPriceExpectedValue = 156;

            int v3BaseRentPriceExpectedValue = 100;
            int v3ActualRentalPriceExpectedValue = 225;

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
