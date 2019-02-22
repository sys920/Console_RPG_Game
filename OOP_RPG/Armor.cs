namespace OOP_RPG
{
    public class Armor
    {
        public string Name { get; }
        public int Defense { get; }
        public int Price { get; }

        public Armor(string name, int defense, int price)
        {
            Name = name;
            Defense = defense;
            Price = price;
        }
    }
}