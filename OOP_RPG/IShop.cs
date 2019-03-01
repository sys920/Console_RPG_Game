namespace OOP_RPG
{
    public interface IShop
    {
        string Name { get; }
        int Price { get; }       
        string GetDescription();
        string GetClass();
    }
}
