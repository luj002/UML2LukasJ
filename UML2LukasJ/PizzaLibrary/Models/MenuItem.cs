public class MenuItem : IMenuItem
{
    private static int _nextNo = 1;

    public string Description { get; set; }
    public string Name { get; set; }
    public int No { get; }
    public double Price { get; set; }
    public MenuType TheMenuType { get; set; }
    public MenuItem(string name, double price, string description, MenuType menuType)
    {
        Name = name;
        Description = description;
        Price = price;
        TheMenuType = menuType;
        No = _nextNo++;
    }
    public override string ToString()
    {
        return $"No: {No}, Name: {Name}, Description: {Description}, Price: {Price:C}, Type: {TheMenuType}";
    }
}