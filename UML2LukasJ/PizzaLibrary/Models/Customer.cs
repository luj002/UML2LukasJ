public class Customer : ICustomer
{
    private static int _nextId = 1;

    public string Address { get; set; }
    public bool ClubMember { get; set; }
    public int Id { get; }
    public string Mobile { get; set; }
    public string Name { get; set; }

    public Customer(string name, string mobile, string address)
    {
        Name = name;
        Mobile = mobile;
        Address = address;
        ClubMember = false;
        Id = _nextId++;
    }
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Mobile: {Mobile}, Address: {Address}, Club Member: {ClubMember}";
    }
}
