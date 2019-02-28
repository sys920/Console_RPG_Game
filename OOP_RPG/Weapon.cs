namespace OOP_RPG
{
    public class Weapon : IWeapon
    {
        public string Name { get; }
        public int Strength { get; }
        public int Price { get; }

        public Weapon(string name, int strength, int price)
        {
            Name = name;
            Strength = strength;
            Price = price;
        }

        public string GetDescription()
        {
            return $"Strenth ({Strength})";
        }

        public string GetClass()
        {
            return "Weapon";
        }
    }
}