public class UserMenu
{
    private static string mainMenuChoices = "\t1.Vis Pizzamenu\n\t2.Vis Kunder\n\t3.Add Customer\n\t4.Add Pizza\n\tQ.Afslut\n\n\tIndtast valg:";

    private CustomerRepository _customerRepository = new CustomerRepository();
    private MenuItemRepository _menuItemRepository = new MenuItemRepository();
    private static string ReadChoice(string choices)
    {
        Console.Clear();
        Console.Write(choices);
        string choice = Console.ReadLine();
        Console.Clear();
        return choice.ToLower();
    }
    private static string ReadInput(string prompt, int minlen = 1)
    {
        Console.WriteLine(prompt);
        string output = Console.ReadLine();
        while (output.Length < minlen)
        {
            Console.WriteLine($"Det skal minimum være {minlen} tegn");
            Console.WriteLine(prompt);
            output = Console.ReadLine();
        }
        return output;
    }
    private static int ReadIntegerInRange(string prompt, int min, int max)
    {
        int result;
        while (true)
        {
            // Assuming ReadInput wraps Console.ReadLine()
            string input = ReadInput(prompt);

            if (int.TryParse(input, out result))
            {
                if (result >= min && result <= max)
                {
                    return result;
                }
                Console.WriteLine($"Tallet skal være mellem {min} og {max}");
            }
            else
            {
                Console.WriteLine("Indtastning skal være et heltal");
            }
        }
    }
    public void ShowMenu()
    {
        string theChoice = ReadChoice(mainMenuChoices);
        while (theChoice != "q")
        {
            switch (theChoice)
            {
                case "1":
                    Console.WriteLine("Valg 1");
                    ShowMenuItemController showMenuItemController = new ShowMenuItemController(_menuItemRepository);
                    showMenuItemController.ShowAllMenuItems();
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Valg 2");
                    _customerRepository.PrintAllCustomers();
                    Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Valg 3");
                    string name = ReadInput("Indlæs navn:");
                    string mobile = ReadInput("Indlæs mobil nr:", 8);
                    while (_customerRepository.GetCustomerByMobile(mobile) != null)
                    {
                        Console.WriteLine($"Nummeret {mobile} er allerede taget");
                        mobile = ReadInput("Indlæs mobil nr:", 8);
                    }
                    string address = ReadInput("Indlæs adresse:");
                    string vipString = ReadInput("Er det en VIP kunde y/n").ToLower();
                    bool isVip = (vipString[0] == 'y') ? true : false;
                    if (isVip)
                    {
                        int discount = ReadIntegerInRange("Indlæs rabat % for VIP kunde:", 1, 25);
                        AddCustomerController addCustomerController = new AddCustomerController(name, mobile, address, discount, _customerRepository);
                        addCustomerController.AddCustomer();
                    }
                    else
                    {
                        string clubMemberString = ReadInput("Vil du være clubmember y/n").ToLower();
                        bool isClubMember = (clubMemberString[0] == 'y') ? true : false;
                        AddCustomerController addCustomerController = new AddCustomerController(name, mobile, address, isClubMember, _customerRepository);
                        addCustomerController.AddCustomer();
                    }
                    break;
                case "4":
                    Console.WriteLine("Valg 4");
                    name = ReadInput("Indlæs navn:");
                    string description = ReadInput("Indlæs beskrivelse:");
                    double price = 0;
                    string priceString = ReadInput("Indlæs pris:");
                    while (!double.TryParse(priceString, out price))
                    {
                        Console.WriteLine("Pris skal være et tal");
                        priceString = ReadInput("Indlæs pris:");
                    }
                    string specialString = ReadInput("Er det en specialpizza y/n").ToLower();
                    bool isSpecial = (specialString[0] == 'y') ? true : false;
                    AddPizzaController addPizzaController = new AddPizzaController(name, price, description, isSpecial, _menuItemRepository);
                    addPizzaController.AddPizza();
                    break;
                default:
                    Console.WriteLine("Angiv et tal fra 1..4 eller q for afslut");
                    break;
            }
            theChoice = ReadChoice(mainMenuChoices);
        }
    }
}
