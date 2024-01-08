using ConsoleApp1.Exceptions;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Units;

namespace CarRental.ClientClasses
{
    public class Client
    {
         
        private string firstName;
        private string lastName;
        private string personalID;
        private Address address;
        private ClientType clientType;
        private int maxCarsCount;

        public Client(string firstName, string lastName, string personalID, Address address, ClientType clientType, int maxCarsCount)
        {
            setFirstName(firstName);
            setLastName(lastName);
            setPersonalID(personalID);
            setAddress(address);
            setClientType(clientType);
            setMaxCarsCount(maxCarsCount);
        }

        public void setFirstName(string firstName)
        {
            if (firstName == "")
            {
                throw new ClientException("First name cannot be empty.");
            }
            else if (firstName == null)
            {
                throw new ClientException("First name cannot be null.");
            }
            this.firstName = firstName;
        }

        public string getFirstName()
        {
            return this.firstName;
        }

        public void setLastName(string lastName)
        {
            if (lastName == "")
            {
                throw new ClientException("Last name cannot be empty.");
            }
            else if (lastName == null)
            {
                throw new ClientException("Last name cannot be null.");
            }
            this.lastName = lastName;
        }

        public string getLastName()
        {
            return this.lastName;
        }

        public void setPersonalID(string personalID)
        {
            if (personalID == "")
            {
                throw new ClientException("Personal ID cannot be empty.");
            }
            else if (personalID == null)
            {
                throw new ClientException("Personal ID cannot be null.");
            }
            else if (personalID.Length != 11)
            {
                throw new ClientException("Personal ID should have 11 characters.");
            }
            this.personalID = personalID;
        }

        public string getPersonalID()
        {
            return this.personalID;
        }

        public void setAddress(Address address)
        {

            if (address == null)
            {
                throw new ClientException("Address cannot be null.");
            }
            this.address = address;
        }

        public Address getAddress()
        {
            return this.address;
        }

        public void setClientType(ClientType newClientType)
        {
            this.clientType = newClientType;
        }

        public ClientType getClientType()
        {
            return this.clientType;
        }

        public void setMaxCarsCount(int maxCarsCount)
        {
            if (maxCarsCount < 0)
            {
                throw new ClientException("Max cars count cannot be a negative number.");
            }
            this.maxCarsCount = maxCarsCount;
        }

        public int getMaxCarsCount()
        {
            return this.maxCarsCount;
        }

        public string getClientInfo()
        {
            return "Client: " + firstName + " " + lastName +
                ", PESEL: " + personalID +
                ", maxCarsCount: " + maxCarsCount +
                ", clientType: " + clientType + "\n" +
                this.address.getAddressInfo();
        }

        public double discount()
        {
            double clientTypeDiscount = 1;

            if (clientType == Units.ClientType.Normal)
            {
                clientTypeDiscount = 1;
            }
            else if (clientType == Units.ClientType.Vip)
            {
                clientTypeDiscount = 0.9;
            }
            else if (clientType == Units.ClientType.SuperVip)
            {
                clientTypeDiscount = 0.7;
            }

            return clientTypeDiscount;
        }
    }
}
