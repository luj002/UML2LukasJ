public class VIPCustomer : Customer
{
    public int Discount { get; set; }
    public VIPCustomer(string name, string mobile, string address, int discountPercentage) : base(name, mobile, address)
    {
        if (discountPercentage < 1 || discountPercentage > 25)
        {
            throw new InvalidDiscountException("discountPercentage", "Discount must be between 1% and 25%");
        }
        ClubMember = true;
        Discount = discountPercentage;
    }
    public override string ToString()
    {
        return base.ToString() + $", VIP Discount: {Discount}%";
    }
}
