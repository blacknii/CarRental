using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.ClientClasses
{
    public class Address
    {
        private string street;
        private string number;

        public Address(string street, string number)
        {
            this.street = street;
            this.number = number;
        }

        public string getAddressInfo()
        {
            return "Address: " + this.street + " " + this.number;
        }

        public void setStreet(string street)
        {
            this.street = street;
        }

        public void setNumber(string number)
        {
            this.number = number;
        }
    }
}
