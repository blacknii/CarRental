using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarRental.ReposytoriesClasses
{
    public abstract class Repository<T>
    {
        private List<T> items;

        public Repository()
        {
            items = new List<T>();
        }

        public void create(T item)
        {
            items.Add(item);
        }

        public void remove(T item)
        {
            items.Remove(item);
        }

        public List<T> getAll()
        {
            return items;
        }

        public void update(T oldItem, T newItem)
        {
            int index = find(oldItem);

            if (index != -1)
            {
                items[index] = newItem;
            }
        }

        public void delete(T item)
        {
            items.Remove(item);
        }

        public int find(T item)
        {
            return items.IndexOf(item);
        }
    }
}
