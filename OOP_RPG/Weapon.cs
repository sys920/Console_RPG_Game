namespace OOP_RPG
{
    public class Weapon
    {
        public string Name { get; }
        public int Strength { get; }

        public Weapon(string name, int strength)
        {
            Name = name;
            Strength = strength;
        }
    }
}