using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Quest
    {
        public string Name { get; set; }
        public bool Difference { get; set; }
        public int Kill { get; set; }
        public int Point { get; set; }
        public bool Complete { get; set; }

        public Quest (string name, bool difference, int kill, int point, bool complete)
        {
            Name = name;
            Difference = difference;
            Kill = kill;
            Point = point;
            Complete = complete;
        }
    }
}
