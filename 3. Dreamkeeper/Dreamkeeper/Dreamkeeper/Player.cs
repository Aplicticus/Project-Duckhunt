using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dreamkeeper
{
    public class Player
    {
        public string name { get; private set; }
        public List<object> inventory { get; private set; }

        public Player(string name)
        {
            this.name = name;
            inventory = new List<object>();
        }

        public void AddItemToInventory(Item item)
        {
            inventory.Add(item);
        }
    }
}
