using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity;
        private ICollection<Item> items;

        public Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }  

        public int Capacity 
        {
            get
            {
                return capacity;
            }
            set
            {
                if (value <= 100)
                {
                    capacity = value;
                }
            }
        }

        public int Load => Items.Sum(w=>w.Weight);

        public IReadOnlyCollection<Item> Items => items.ToList().AsReadOnly();

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            if (!items.Any(i => i.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            Item item = items.FirstOrDefault(i => i.GetType().Name == name);
            items.Remove(item);
            return item;
        }
    }
}
