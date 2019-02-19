namespace OOP_RPG
{
    public class Armor
    {
        public string Name { get; }
        public int Defense { get; }

        public Armor(string name, int defense)
        {
            Name = name;
            Defense = defense;
        }
    }
}