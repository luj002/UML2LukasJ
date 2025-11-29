public class CompanyInfo
{
    public string Vat { get; set; }
    public string CVR { get; set; }
    public string Name { get; set; }
    public int ClubDiscount { get; set; }
    private static CompanyInfo _instance;
    private CompanyInfo()
    {
           
    }
    public static CompanyInfo Instance 
    {
        get 
        {
            if (_instance == null)
            {
                _instance = new CompanyInfo();
            }
            return _instance;
        }
    }
}
