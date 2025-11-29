public class AddCustomerController
{
	ICustomerRepository _customerRepository;
	public ICustomer Customer { get; set; }

	public AddCustomerController(string name, string mobile, string address, bool clubMember, ICustomerRepository customerRepository)
	{
        Customer = new Customer(name, mobile, address);
        Customer.ClubMember = clubMember;
        _customerRepository = customerRepository;

    }
    public AddCustomerController(string name, string mobile, string address, int discount, ICustomerRepository customerRepository)
    {
        Customer = new VIPCustomer(name, mobile, address, discount);
        _customerRepository = customerRepository;

    }

    public void AddCustomer()
	{
		_customerRepository.AddCustomer(Customer);
	}


}
