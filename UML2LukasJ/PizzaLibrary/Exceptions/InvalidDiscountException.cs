public class InvalidDiscountException : ArgumentOutOfRangeException
{
    public InvalidDiscountException(string argument, string message) : base(argument, message)
    {
    }
}
