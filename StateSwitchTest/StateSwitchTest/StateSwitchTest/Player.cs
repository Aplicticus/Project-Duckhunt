using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateSwitchTest
{
    class Player
    {
        public string name { get; private set; }
        public List<object> inventory;

        public Player(string name)
        {
            this.name = name;
        }
    }
}
