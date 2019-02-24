namespace OOP_RPG
{
    public class Monster
    {
        public string Name { get;  }
        public int Strength { get;  }
        public int Defense { get;  }
        public int OriginalHP { get;  }
        public int CurrentHP { get; set; }
        public MonsterLevel Diffculty { get; }
        public MonsterOfTheDay Weekday { get; }

        public Monster(string name, int strength, int defense, int hp, MonsterLevel diffculty, MonsterOfTheDay weekday)
        {
            Name = name;
            Strength = strength;
            Defense = defense;
            OriginalHP = hp;
            CurrentHP = hp;
            Diffculty = diffculty;
            Weekday = weekday;
        }
    }

}