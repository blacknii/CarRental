using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.VehicleClasses
{
    public abstract class Vehicle
    {
        private string id;
        private int baseRentPrice;

        public Vehicle(string id, int baseRentPrice)
        {
            this.id = id;
            this.baseRentPrice = baseRentPrice;
        }

        public string getId()
        {
            return this.id;
        }
        public virtual int getBaseRentPrice()
        {
            return this.baseRentPrice;
        }

        public virtual int getActualRentalPrice()
        {
            return this.baseRentPrice;
        }

        public virtual string getVehicleInfo()
        {
            return "Type: Vehicle, ID: " + getId() + ", Price: " + getActualRentalPrice();
        }
    }
}
