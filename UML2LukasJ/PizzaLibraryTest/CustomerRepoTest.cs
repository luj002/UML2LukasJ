namespace PizzaLibraryTest;

[TestClass]
public sealed class CustomerRepoTest
{
	[TestMethod]
	public void CustomerRepoCount()
	{
		// Arrange
		CustomerRepository customerRepository = new CustomerRepository();
		// Act
		int repoCount = customerRepository.Count;
		int mockCount = MockData.Customers.Count;
		// Assert
		Assert.AreEqual(mockCount, repoCount);
	}
	[TestMethod]
	public void CustomerRepoGetAll()
	{
		// Arrange
		CustomerRepository customerRepository = new CustomerRepository();
		// Act
		List<ICustomer> allCustomers = customerRepository.GetAll();
		int repoCount = customerRepository.Count;
		// Assert
		Assert.AreEqual(repoCount, allCustomers.Count);
	}
	[TestMethod]
	public void CustomerRepoAddCustomer()
	{
		// Arrange
		CustomerRepository customerRepository = new CustomerRepository();
		int initialCount = customerRepository.Count;
		// Act
		customerRepository.AddCustomer(new Customer("Test", "2235", "SugarStreet"));
		int newCount = customerRepository.Count;
		// Assert
		Assert.AreEqual(initialCount + 1, newCount);
	}
	[TestMethod]
	public void CustomerRepoGetCustomerByMobile()
	{
		// Arrange
		CustomerRepository customerRepository = new CustomerRepository();
		List<ICustomer> allCustomers = customerRepository.GetAll();
		// Act
		foreach(ICustomer existingCustomer in allCustomers)
		{
			ICustomer? retrievedCustomer = customerRepository.GetCustomerByMobile(existingCustomer.Mobile);
			// Assert
			Assert.IsNotNull(retrievedCustomer);
			Assert.AreEqual(existingCustomer.Mobile, retrievedCustomer!.Mobile);
		}
	}
	[TestMethod]
	public void CustomerRepoRemoveCustomer()
	{
		// Arrange
		CustomerRepository customerRepository = new CustomerRepository();
		customerRepository.AddCustomer(new Customer("Test","2235","SugarStreet"));
		int initialCount = customerRepository.Count;
		// Act
		customerRepository.RemoveCustomer("2235");
		int finalCount = customerRepository.Count;
		// Assert
		Assert.AreEqual(initialCount-1, finalCount);
	}
	[TestMethod]
	public void CustomerRepoPrintAllCustomers()
	{
		// Arrange
		CustomerRepository customerRepository = new CustomerRepository();
		// Act
		customerRepository.PrintAllCustomers();
		// Assert
		Assert.IsTrue(true); // If no exception is thrown, the test passes
	}
}