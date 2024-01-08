using CarRental.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // Actual code
            Console.WriteLine(a1.getAddressInfo());
            Console.WriteLine(a2.getAddressInfo());
            Console.WriteLine(a3.getAddressInfo());

            Console.ReadKey();
        }
    }
}
