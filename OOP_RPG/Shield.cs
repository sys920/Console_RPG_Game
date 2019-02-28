namespace OOP_RPG
{
    public class Shield : IShield
    {
        public string Name { get; }
        public int Defense { get; }
        public int Price { get; }

        public Shield (string name, int defense, int price)
        {
            Name = name;
            Defense = defense;
            Price = price;
        }

        public string GetDescription()
        {
            return $"Defense ({Defense})";
        }

        public string GetClass()
        {
            return "Shield";
        }
    }
}
