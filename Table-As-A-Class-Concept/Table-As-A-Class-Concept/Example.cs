using System;

public class Customer
{
    public string No_
    {
        get
        {
            NoSeriesManagement test = new NoSeriesManagement();
            return test.GetNextNo("");;
        }
        set { No_ = value; }
    }
    public string Name { get; set; }
    public string SearchName { get; set; }
    public string Address { get; set; }
    //...
    public float CreditLimitLCY { get; set; }
    //...
    public int StatisticsGroup { get; set; }

    public string[] formatAddress()
    {
        FormatAddress FormatAddress = new FormatAddress();
        return(FormatAddress.formatCustomer(this));
    }
	
}

public class SalesHeader
{
    public int DocumentType { get; set; }
    public string SelltoCustomerNo_ { get; set; }
    public string No_ { get; set; }
    public string YourReference { get; set; }
    public DateTime OrderDate 
    {
        get { return PostingDate;}
        set { PostingDate = value; } 
    }
    public DateTime PostingDate { get; set; }
    public string SelltoCustomerName 
    { 
        get; 
        set; 
    }
    public string SelltoAddress { get; set; }
    
    public void OnValidateSelltoCustomerNo_ (Customer Customer)
    {
        SelltoCustomerName = Customer.Name;
        SelltoAddress = Customer.Address;
    }

    public SalesInvoice Post()
    {
        SalesPost SalesPost = new SalesPost();
        return(SalesPost.OnRun(this));
    }
}

public class SalesInvoice
{
    public string SelltoCustomerNo_ { get; set; }
    public string No_ { get; set; }
    public string YourReference { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime PostingDate { get; set; }
    public string SelltoCustomerName { get; set; }
    public string SelltoAddress { get; set; }
    
    public string[] formatAddress()
    {
        FormatAddress FormatAddress = new FormatAddress();
        return (FormatAddress.formatSalesInvoice(this));
    }
}

public class SalesPost 
{
    public SalesInvoice OnRun(SalesHeader SalesHeader)
    {
        SalesInvoice SalesInvoice = new SalesInvoice();
        SalesInvoice.No_ = SalesHeader.No_;
        SalesInvoice.SelltoCustomerNo_ = SalesHeader.SelltoCustomerNo_;
        SalesInvoice.YourReference = SalesHeader.YourReference;
        SalesInvoice.OrderDate = SalesHeader.OrderDate;
        SalesInvoice.PostingDate = SalesHeader.PostingDate;
        SalesInvoice.SelltoCustomerName = SalesHeader.SelltoCustomerName;
        SalesInvoice.SelltoAddress = SalesHeader.SelltoAddress;
        return (SalesInvoice);
    }
}

public class FormatAddress
{
    public string[] formatCustomer (Customer Customer)
    {
        return (formatAddr(Customer.Name, Customer.Address));
    }
    public string[] formatSalesInvoice(SalesInvoice SalesInvoice)
    {
        return (formatAddr(SalesInvoice.SelltoCustomerName, SalesInvoice.SelltoAddress));
    }
    private string[] formatAddr(string Name, string Address)
    {
        string[] AddrArray;
        AddrArray = new string[7];
        AddrArray[0] = Name;
        AddrArray[1] = Address;
        return (AddrArray);
    }
}

public class NoSeriesManagement
{
    public string GetNextNo(string NoSeriesCode)
    {
        return ("C00010");
    }
}