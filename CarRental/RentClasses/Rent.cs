using CarRental.ClientClasses;
using CarRental.VehicleClasses;
using ConsoleApp1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.RentClasses
{
    public class Rent
    {
        public Guid id;
        public Client client;
        public Vehicle vehicle;
        public DateTime rentStartDateTime;
        public DateTime rentEndDateTime;

        public Rent(Client client, Vehicle vehicle, DateTime rentStartDateTime)
        {
            this.id = Guid.NewGuid();
            setClient(client);
            setVehicle(vehicle);
            setRentStartDateTime(rentStartDateTime);
        }

        public string getIdInfo()
        {
            return "Rent id: " + this.id;
        }

        public void setClient(Client client)
        {
            if (client == null)
            {
                throw new RentException("Client cannot be null.");
            }
            this.client = client;
        }

        public Client getClient()
        {
            return this.client;
        }

        public string getRentClientInfo()
        {
            return client.getFirstName() + " " + client.getLastName();
        }

        public void setVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new RentException("Vehicle cannot be null.");
            }
            this.vehicle = vehicle;
        }

        public Vehicle getVehicle()
        {
            return this.vehicle;
        }

        public string getRentVehicleInfo()
        {
            return vehicle.getVehicleInfo();
        }

        public void setRentStartDateTime(DateTime rentStartDateTime)
        {
            if (rentStartDateTime == null)
            {
                throw new RentException("Rent start date time cannot be null.");
            }
            else if (rentStartDateTime.Year < 2011)
            {
                throw new RentException("Our company did not exist before 2011.");
            }
            this.rentStartDateTime = rentStartDateTime;
        }

        public DateTime getRentStartDateTime()
        {
            return this.rentStartDateTime;
        }

        public string getRentStartDateTimeInfo()
        {
            return "Rent start date: " + getRentStartDateTime();
        }

        public DateTime getRentEndDateTime()
        {
            return this.rentEndDateTime;
        }

        public string getRentEndDateTimeInfo()
        {
            return "Rent end date: " + getRentEndDateTime();
        }

        public int getRentDuration()
        {
            return (rentEndDateTime == DateTime.MinValue ? 0 : (int)(rentEndDateTime - rentStartDateTime).TotalDays + 1);
        }

        public string getRentDurationInfo()
        {
            return "Rent duration: " + getRentDuration();
        }

        public int getRentCost()
        {
            return (int)(getRentDuration() * vehicle.getActualRentalPrice() * client.getDiscount());
        }

        public string getRentCostInfo()
        {
            return "Rent cost: " + getRentCost();
        }

        public void returnVehicle(DateTime returnDateTime)
        {

            if (returnDateTime < rentEndDateTime)
            {
                throw new RentException("Return date cannot be earlier than the previous return date.");
            }
            this.rentEndDateTime = returnDateTime;
        }

        public string getRentInfo()
        {
            string endDateOrdayCount = (rentEndDateTime == DateTime.MinValue
                ? "\n" + getRentDurationInfo()
                : "\n" + getRentEndDateTimeInfo());

            return getIdInfo() + 
                "\n" + getRentStartDateTimeInfo() +
                "\n" + getRentCostInfo() + 
                "\n" + getRentClientInfo() + 
                "\n" + getRentVehicleInfo();
        }

    }
}
