using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.VehicleClasses
{
    internal abstract class MotorVehicle : Vehicle
    {
        private int engineDisplacement;
        public MotorVehicle(string id, int baseRentPrice, int engineDisplacement) : base(id, baseRentPrice)
        {
            this.engineDisplacement = engineDisplacement;
        }

        public int getEngineDisplacement()
        {
            return this.engineDisplacement;
        }

        public int getAdditionalPrice()
        {
            int additionalPrice = 100;

            if (this.engineDisplacement < 1000)
            {
                additionalPrice = 0;
            }
            else if (this.engineDisplacement >= 1000 && this.engineDisplacement <= 2000)
            {
                additionalPrice = (int)((5 * (this.engineDisplacement - 1000)) * getBaseRentPrice() / 10000);
            }
            else
            {
                additionalPrice = (int)(base.getBaseRentPrice() * 0.5);
            }

            return additionalPrice;
        }

        public override int getActualRentalPrice()
        {
            return getBaseRentPrice() + getAdditionalPrice();
        }

        public override string getVehicleInfo()
        {
            return "Type: MotorVehicle, ID: " + getId() + ", Price: " + getActualRentalPrice();
        }
    }
}
