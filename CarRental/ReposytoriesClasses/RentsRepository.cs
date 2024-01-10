using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.RentClasses;

namespace CarRental.ReposytoriesClasses
{
    public class RentsRepository : Repository<Rent>
    {
        private List<Rent> itemsArchive;
        public RentsRepository()
        {
            itemsArchive = new List<Rent>();
        }

        public void createArchive(Rent item)
        {
            itemsArchive.Add(item);
        }

        public void removeArchive(Rent item)
        {
            itemsArchive.Remove(item);
        }

        public List<Rent> getAllArchive()
        {
            return itemsArchive;
        }

        public void updateArchive(Rent oldItem, Rent newItem)
        {
            int index = findArchive(oldItem);

            if (index != -1)
            {
                itemsArchive[index] = newItem;
            }
        }

        public void deleteArchive(Rent item)
        {
            itemsArchive.Remove(item);
        }

        public int findArchive(Rent item)
        {
            return itemsArchive.IndexOf(item);
        }
    }
}
