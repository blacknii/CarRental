using CarRental.ClientClasses;
using CarRental.ReposytoriesClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ConsoleApp1.Units;
using System.Collections.Generic;
using CarRental.VehicleClasses;
using ConsoleApp1;

namespace RepositoryUnitTests
{
    [TestClass]
    public class VehicleRepositoryUnitTest
    {
        [TestMethod]
        public void BasicFunctionality()
        {
            // Arrange
            Car v1 = new Car("234", 600, 900, Units.Segment.A);
            Car v2 = new Car("233", 350, 1600, Units.Segment.C);
            Car v3 = new Car("289", 4000, 5000, Units.Segment.E);

            VehicleRepository vr1 = new VehicleRepository();

            // Act
            vr1.create(v1);
            vr1.create(v2);
            vr1.create(v3);

            List<Vehicle> vr1ExpectedValue = new List<Vehicle> { v1, v2, v3 };

            // Assert
            CollectionAssert.AreEqual(vr1.getAll(), vr1ExpectedValue, "getAll() or create() doesn't work correctly");

            // Act
            vr1.remove(v1);
            vr1.delete(v2);

            List<Vehicle> vr1ExpectedValue2 = new List<Vehicle> { v3 };

            // Assert
            CollectionAssert.AreEqual(vr1.getAll(), vr1ExpectedValue2, "getAll(), remove() or delete() doesn't work correctly");

            // Act
            vr1.update(v3, v1);

            List<Vehicle> vr1ExpectedValue3 = new List<Vehicle> { v1 };

            // Assert
            CollectionAssert.AreEqual(vr1.getAll(), vr1ExpectedValue3, "getAll() or update() doesn't work correctly");

            // Act and Assert
            Assert.AreEqual(vr1.find(v1), 0, "getAll() or find() doesn't work correctly");
        }
    }
}
