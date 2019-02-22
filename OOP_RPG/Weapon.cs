namespace OOP_RPG
{
    public class Weapon
    {
        public string Id { get; }
        public string Name { get; }
        public int Strength { get; }
        public int Price { get; }

        public Weapon(string id, string name, int strength, int price)
        {
            Id = id;
            Name = name;
            Strength = strength;
            Price = price;
        }
    }
}