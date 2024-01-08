using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.VehicleClasses
{
    internal class Moped : MotorVehicle
    {
        public Moped(string id, int baseRentPrice, int engineDisplacement) : base(id, baseRentPrice, engineDisplacement)
        {

        }

        public override string getVehicleInfo()
        {
            return "Type: Moped, ID: " + base.getId() + ", Price: " + base.getActualRentalPrice();
        }
    }
}
