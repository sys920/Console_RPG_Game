using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Achievement
    {
        public string Name { get; set; }
        public int Point { get; set; }
        public DateTime Date { get; set; }
        
        public Achievement (string name, int point, DateTime date)
        {
            Name = name;
            Point = point;
            Date = date;
        }       
    }
}
