using CarRental.ClientClasses;
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

            // Actual code
            Console.WriteLine(c1.getClientInfo());
            Console.WriteLine(c2.getClientInfo());
            Console.WriteLine(c3.getClientInfo());

            Console.ReadKey();
        }
    }
}
