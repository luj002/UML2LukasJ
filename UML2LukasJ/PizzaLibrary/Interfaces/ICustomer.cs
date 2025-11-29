public interface ICustomer
{
    string Address { get; set; }
    bool ClubMember { get; set; }
    int Id { get; }
    string Mobile { get; set; }
    string Name { get; set; }
    string ToString();
}