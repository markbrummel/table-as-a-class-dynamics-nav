using System;

public class Customer
{
    public string No_ { get; set; }
    public string Name { get; set; }
    public string SearchName { get; set; }
    public string Address { get; set; }
    //...
    public float CreditLimitLCY { get; set; }
    //...
    public int StatisticsGroup { get; set; }

    public string formatAddress()
    {
        return ( Address );
    }
	
}
