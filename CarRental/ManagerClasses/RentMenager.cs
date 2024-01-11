using CarRental.ClientClasses;
using CarRental.RentClasses;
using CarRental.ReposytoriesClasses;
using CarRental.VehicleClasses;
using ConsoleApp1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Units;

namespace CarRental.ManagerClasses
{
    public class RentMenager
    {
        private RentsRepository rentsRepository;
        private ClientRepository clientRepository;

        public RentMenager(RentsRepository rentsRepository, ClientRepository clientRepository)
        {
            this.rentsRepository = rentsRepository;
            this.clientRepository = clientRepository;
        }

        private bool isClientInRepository(Client client)
        {
            return clientRepository.find(client) != -1;
        }
        private bool isClientAllowedToRentMoreVehicles(Client client)
        {
            return getCurrentlyRentedVehicles(client).Count < client.getMaxCarsCount();
        }

        private bool isCarInUse(Vehicle vehicle)
        {
            bool isVehicleFree = false;
            foreach (var rent in rentsRepository.getAll())
            {
                if (rent.getVehicle() == (vehicle))
                {
                    isVehicleFree = true; break;
                }
            }
            return isVehicleFree;
        }

        private Rent getRentOfVehicle(Vehicle vehicle)
        {
            foreach (var rent in rentsRepository.getAll())
            {
                if (rent.getVehicle() == (vehicle))
                {
                    return rent;
                }
            }
            return null;
        }

        private List<Vehicle> getCurrentlyRentedVehicles(Client client)
        {
            List<Vehicle> currentlyRentedVehicles = new List<Vehicle>();
            foreach (var rent in rentsRepository.getAll())
            {
                if (rent.getClient() == client)
                {
                    currentlyRentedVehicles.Add(rent.getVehicle());
                }
            }
            return currentlyRentedVehicles;
        }

        private List<Rent> getAllClientRents(Client client)
        {
            List<Rent> archivedRents = new List<Rent>();
            foreach (var rent in rentsRepository.getAllArchive())
            {
                if (rent.getClient() == client)
                {
                    archivedRents.Add(rent);
                }
            }
            return archivedRents;
        }

        public void rentVehicle(Client client, Vehicle vehicle, DateTime dateTime)
        {
            if (isCarInUse(vehicle)) throw new RentMenagerException("Vehicle is already in use");
            if (!isClientAllowedToRentMoreVehicles(client)) throw new RentMenagerException("This user cannot rent any more vehicles.");

            this.rentsRepository.create(new Rent(client, vehicle, dateTime));

            if(isClientInRepository(client))
            {
                this.clientRepository.create(client);
            }
        }

        public void returnVehicle(Vehicle vehicle)
        {
            if (!isCarInUse(vehicle)) throw new RentMenagerException("Cannot return the vehicle as it is not currently rented.");
            Rent rent = getRentOfVehicle(vehicle);
            rent.returnVehicle(DateTime.Now);
            rentsRepository.createArchive(rent);
            rentsRepository.remove(rent);
        }

        public int checkClientRentBallance(Client client)
        {
            int ballance = 0;

            foreach (Rent rent in getAllClientRents(client))
            {
                ballance += rent.getRentCost();
            }

            return ballance;
        }

        public void changeClientType(Client client)
        {
            int ballance = checkClientRentBallance(client);

            ClientType clientType = client.getClientType();

            if (ballance > 30000)
            {
                clientType = ClientType.SuperVip;
            }
            else if (ballance > 10000)
            {
                clientType = ClientType.Vip;
            }
            else
            {
                clientType = ClientType.Normal;
            }

            client.setClientType(clientType);
        }

        public string rentReport()
        {
            string curretRentsInfo = "List of all curret rents rents: ";
            foreach (Rent rent in this.rentsRepository.getAll())
            {
                curretRentsInfo += "\n" + rent.getRentInfo() + "\n--------------------------------";
            }
            string archiveRentsInfo = "List of all archive rents rents: ";
            foreach (Rent rent in this.rentsRepository.getAllArchive())
            {
                archiveRentsInfo += "\n" + rent.getRentInfo() + "\n--------------------------------";
            }
            return curretRentsInfo + "\n\n" + archiveRentsInfo;
        }

    }
}
