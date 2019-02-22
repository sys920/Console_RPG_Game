namespace OOP_RPG
{
    public class Armor
    {
        public string Id { get; }
        public string Name { get; }
        public int Defense { get; }
        public int Price { get; }

        public Armor(string id, string name, int defense, int price)
        {
            Id = id;
            Name = name;
            Defense = defense;
            Price = price;
        }
    }
}