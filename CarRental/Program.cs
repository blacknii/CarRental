using CarRental.ClientClasses;
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
            Client c1 = new Client("Adam", "Mickiewicz", "66071089838", a1, Units.ClientType.Normal, 3);
            Client c2 = new Client("Tomasz", "Mickiewicz", "51012413685", a2, Units.ClientType.Vip, 6);
            Client c3 = new Client("Adam", "Małysz", "49081079686", a3, Units.ClientType.SuperVip, 10);

            // Creating Vehicles
            Bicycle v1 = new Bicycle("22", 100);
            Moped v2 = new Moped("33", 100, 3000);
            Car v3 = new Car("11", 1000, 3000, Units.Segment.D);

            // Actual code
            VehicleRepository vr = new VehicleRepository();
            foreach (Vehicle vehicle in vr.getAll()) 
            {
                Console.WriteLine(vehicle.getVehicleInfo());
            }
            Console.WriteLine("------------------------------");
            vr.create(v1);
            foreach (Vehicle vehicle in vr.getAll())
            {
                Console.WriteLine(vehicle.getVehicleInfo());
            }
            Console.WriteLine("------------------------------");
            vr.create(v2);
            foreach (Vehicle vehicle in vr.getAll())
            {
                Console.WriteLine(vehicle.getVehicleInfo());
            }
            Console.WriteLine("------------------------------");
            vr.remove(v1);
            vr.create(v3);
            foreach (Vehicle vehicle in vr.getAll())
            {
                Console.WriteLine(vehicle.getVehicleInfo());
            }
            Console.WriteLine("------------------------------");
            vr.update(v3, v1);
            foreach (Vehicle vehicle in vr.getAll())
            {
                Console.WriteLine(vehicle.getVehicleInfo());
            }
            Console.WriteLine("------------------------------");

            Console.ReadKey();
        }
    }
}
