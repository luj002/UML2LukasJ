public class MenuItemRepository : IMenuItemRepository
{
    private readonly List<IMenuItem> _menuItems;

    public int Count { get { return _menuItems.Count; } }

    public MenuItemRepository()
    {
        _menuItems = MockData.MenuItems;
	}

    public List<IMenuItem> GetAll()
    {
        return _menuItems;
    }

    public void AddMenuItem(IMenuItem IMenuItem)
    {
        foreach (var item in _menuItems)
        {
            if (item == IMenuItem)
            {
                return;
            }
        }
        _menuItems.Add(IMenuItem);
    }

    public IMenuItem? GetMenuItemByNo(int no)
    {
        foreach (var item in _menuItems)
        {
            if (item.No == no)
            {
                return item;
            }
        }
        return null;
    }

    public void RemoveMenuItem(int no)
    {
        foreach(var item in _menuItems)
        {
            if (item.No == no)
            {
                _menuItems.Remove(item);
                return;
            }
        }
    }

    public void PrintAllMenuItems()
    {
        foreach(var item in _menuItems)
        {
            Console.WriteLine(item);
        }
    }
    public List<IMenuItem> GetAllOfType(MenuType type)
    {
        List<IMenuItem> allOfType = [];
        foreach (var item in _menuItems)
        {
            if (item.TheMenuType == type)
            {
                allOfType.Add(item);
            }
        }
        return allOfType;
	}
    public IMenuItem GetMostExpensiveOf(MenuType type)
    {
        List<IMenuItem> itemsOfType = GetAllOfType(type);
        IMenuItem mostExpensive = itemsOfType[0];
        foreach (var item in itemsOfType)
        {
            if (item.Price > mostExpensive.Price)
            {
                mostExpensive = item;
            }
        }
        return mostExpensive;
    }
    public IMenuItem GetMostExpensivePizza()
    {
        IMenuItem mostExpensiveClassic = GetMostExpensiveOf(MenuType.PIZZECLASSICHE);
        IMenuItem mostExpensiveSpecial = GetMostExpensiveOf(MenuType.PIZZESPECIALI);
        return mostExpensiveClassic.Price > mostExpensiveSpecial.Price ? mostExpensiveClassic : mostExpensiveSpecial;
    }
    public void PrintMenuCard()
    {
        foreach (MenuType type in Enum.GetValues(typeof(MenuType)))
        {
            Console.WriteLine($"\n--- {type} ---");
            List<IMenuItem> itemsOfType = GetAllOfType(type);
            foreach (var item in itemsOfType)
            {
                Console.WriteLine(item);
            }
        }
    }
	public override string ToString()
	{
        string strings = "";
		foreach (var item in _menuItems)
        {
            strings += item + "\n";
		}
        return strings;
	}
}
