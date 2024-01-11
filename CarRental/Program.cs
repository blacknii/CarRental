using CarRental.ClientClasses;
using CarRental.ManagerClasses;
using CarRental.RentClasses;
using CarRental.ReposytoriesClasses;
using CarRental.VehicleClasses;
using ConsoleApp1;
using System;

namespace CarRental
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating Addresseses 
            Address a1 = new Address("Perichora", "23");
            Address a2 = new Address("Bema", "12");
            Address a3 = new Address("Sienna", "23");

            // Creating Clients
            Client c1 = new Client("Adam", "Mickiewicz", "66071089838", a1, Units.ClientType.Normal, 5);
            Client c2 = new Client("Tomasz", "Mickiewicz", "51012413685", a2, Units.ClientType.Vip, 3);
            Client c3 = new Client("Adam", "Małysz", "49081079686", a3, Units.ClientType.SuperVip, 10);

            // Creating Vehicles
            Bicycle v1 = new Bicycle("22", 100);
            Moped v2 = new Moped("33", 100, 3000);
            Car v3 = new Car("11", 1000, 3000, Units.Segment.D);

            // Creating Reposytories
            ClientRepository cr1 = new ClientRepository();
            VehicleRepository vr1 = new VehicleRepository();
            RentsRepository rr1 = new RentsRepository();

            // Creating menager
            RentMenager rm1 = new RentMenager(rr1, cr1);
            rm1.rentVehicle(c1, v1, DateTime.Now.AddDays(-1000));
            rm1.rentVehicle(c2, v2, DateTime.Now.AddDays(-15));
            rm1.rentVehicle(c2, v3, DateTime.Now.AddDays(-30));

            rm1.returnVehicle(v3);
            rm1.returnVehicle(v1);
            rm1.rentVehicle(c3, v3, DateTime.Now.AddDays(-10));
            rm1.rentVehicle(c3, v1, DateTime.Now.AddDays(-10));
            rm1.returnVehicle(v1);

            // Actual code
            Console.WriteLine(rm1.rentReport());
            Console.WriteLine(rm1.checkClientRentBallance(c1));
            Console.WriteLine(rm1.checkClientRentBallance(c2));
            Console.WriteLine(rm1.checkClientRentBallance(c3));
            Console.WriteLine(c1.getClientType());
            rm1.changeClientType(c1);
            Console.WriteLine(c1.getClientType());

            Console.ReadKey();
        }
    }
}
