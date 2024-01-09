using ConsoleApp1.Exceptions;
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
            setId(id);
            setBaseRentPrice(baseRentPrice);
        }

        public void setId(string id)
        {
            if (id == "")
            {
                throw new VehicleException("Id cannot be empty.");
            }
            else if (id == null)
            {
                throw new VehicleException("Id cannot be null.");
            }
            this.id = id;
        }

        public virtual string getId()
        {
            return this.id;
        }

        public virtual void setBaseRentPrice(int baseRentPrice)
        {
            if (baseRentPrice < 0)
            {
                throw new VehicleException("Base rent price cannot be a negative number.");
            }
            this.baseRentPrice = baseRentPrice;
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
