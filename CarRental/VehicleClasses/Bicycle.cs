using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.VehicleClasses
{
    public class Bicycle : Vehicle
    {
        public Bicycle(string id, int baseRentPrice) : base(id, baseRentPrice) { }

        public override string getVehicleInfo()
        {
            return "Type: Bike, ID: " + base.getId() + ", Price: " + base.getActualRentalPrice();
        }
    }
}
