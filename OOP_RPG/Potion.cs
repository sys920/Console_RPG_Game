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
        public int HealthRestored { get; }
        public int Price { get; }

        public Potion (string name, int healthRestroed, int price)
        {
            Name = name;           
            HealthRestored = healthRestroed;
            Price = price;
        }
    }
}


