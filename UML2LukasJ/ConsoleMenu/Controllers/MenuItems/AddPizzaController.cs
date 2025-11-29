public class AddPizzaController
{
	IMenuItemRepository _menuItemRepository;
	public MenuItem MenuItem { get; set; }

	public AddPizzaController(string name, double price, string description, bool special, IMenuItemRepository menuItemRepository)
	{
		MenuItem = new MenuItem(name, price, description, special ? MenuType.PIZZESPECIALI : MenuType.PIZZECLASSICHE);
        _menuItemRepository = menuItemRepository;
	}

	public void AddPizza()
	{
        _menuItemRepository.AddMenuItem(MenuItem);
    }


}
