namespace OOP_RPG
{
    public class Monster
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public MonsterLevel Diffculty { get; set; }
        
        public Monster(string name, int strength, int defense, int hp, MonsterLevel diffculty)
        {
            Name = name;
            Strength = strength;
            Defense = defense;
            OriginalHP = hp;
            CurrentHP = hp;
            Diffculty = diffculty;
        }
    }

}