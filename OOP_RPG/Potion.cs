using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Potion
    {
        public string Name { get; }
        public int Price { get; }
        public int HealthRestored { get; }

        public Potion (string name, int price, int healthRestroed)
        {
            Name = name;
            Price = price;
            HealthRestored = healthRestroed;
        }
    }
}


