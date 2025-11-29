public class CustomerRepository : ICustomerRepository
{
    private readonly Dictionary<string, ICustomer> _customers;

    public int Count { get { return _customers.Count; } }

    public CustomerRepository()
    {
        _customers = MockData.Customers;
	}

    public List<ICustomer> GetAll()
    {
        return _customers.Values.ToList();
    }

    public void AddCustomer(ICustomer customer)
    {
        if (!_customers.ContainsKey(customer.Mobile))
        {
            _customers[customer.Mobile] = customer;
        }
        else
        {
            throw new CustomerMobileNumberExist($"Customer with mobile {customer.Mobile} already exists.");
        }
    }

    public ICustomer? GetCustomerByMobile(string mobile)
    {
        return _customers.ContainsKey(mobile) ? _customers[mobile] : null;
    }

    public void RemoveCustomer(string mobile)
    {
        _customers.Remove(mobile);
    }

    public void PrintAllCustomers()
    {
        foreach(var customer in _customers.Values)
        {
            Console.WriteLine(customer);
        }
    }
	public List<ICustomer> GetAllClubMembers()
	{
		List<ICustomer> clubMembers = [];
		foreach (var customer in _customers.Values)
		{
			if (customer.ClubMember)
			{
				clubMembers.Add(customer);
			}
		}
		return clubMembers;
	}
	public List<ICustomer> GetAllRoskildeCustomers()
	{
		List<ICustomer> roskildeMembers = [];
		foreach (var customer in _customers.Values)
		{
            if (customer.Address.ToLower().Contains("roskilde"))
			{
				roskildeMembers.Add(customer);
			}
		}
		return roskildeMembers;
	}
}
