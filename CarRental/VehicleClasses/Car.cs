using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Units;

namespace CarRental.VehicleClasses
{
    public class Car : MotorVehicle
    {
        private Segment segment;
        public Car(string id, int baseRentPrice, int engineDisplacement, Segment segment) : base(id, baseRentPrice, engineDisplacement)
        {
            setSegment(segment);
        }

        public void setSegment(Segment segment)
        {
            this.segment = segment;
        }

        public Segment getSegment()
        {
            return this.segment;
        }

        public double getSegmentMultiplier()
        {
            double segmentMultiplier = 1;

            switch (segment)
            {
                case Units.Segment.A:
                    segmentMultiplier = 1;
                    break;
                case Units.Segment.B:
                    segmentMultiplier = 1.1;
                    break;
                case Units.Segment.C:
                    segmentMultiplier = 1.2;
                    break;
                case Units.Segment.D:
                    segmentMultiplier = 1.3;
                    break;
                case Units.Segment.E:
                    segmentMultiplier = 1.5;
                    break;
                default:
                    break;
            }

            return segmentMultiplier;
        }

        public override int getActualRentalPrice()
        {
            return (int)((getBaseRentPrice() + getAdditionalPrice()) * getSegmentMultiplier());
        }

        public override string getVehicleInfo()
        {
            return "Type: Car, ID: " + base.getId() + ", Price: " + base.getActualRentalPrice() + ", Engine displacement: " + base.getEngineDisplacement() + ", Segment: " + getSegment();

        }
    }
}
