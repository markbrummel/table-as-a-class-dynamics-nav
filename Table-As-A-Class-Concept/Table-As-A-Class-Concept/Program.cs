using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table_As_A_Class_Concept
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Create the Customer Record..............");

            Customer Cust = new Customer();
            Cust.Name = "Mark Brummel";
            Cust.Address = "Somewhere";
            
            Console.WriteLine(Cust.No_);

            Console.WriteLine("Return the Customer Address..............");

            foreach (string Addr in Cust.formatAddress())
                Console.WriteLine(Addr);

            Console.WriteLine("Create the Sales Header..............");

            SalesHeader SalesHdr = new SalesHeader();
            SalesHdr.SelltoCustomerNo_ = Cust.No_;
            SalesHdr.OnValidateSelltoCustomerNo_(Cust);
            SalesHdr.PostingDate = new DateTime(2014, 11, 27);

            Console.WriteLine("Show Customer Name..............");

            Console.WriteLine(SalesHdr.SelltoCustomerName);
            Console.WriteLine(SalesHdr.OrderDate.ToString());
                     
            Console.WriteLine("Post Sales Header..............");

            SalesInvoice SalesInv = SalesHdr.Post();

            Console.WriteLine(SalesInv.SelltoCustomerName);

            Console.WriteLine("Print Address Sales Invoice..............");
            
            foreach (string Addr in SalesInv.formatAddress())
                Console.WriteLine(Addr);

            Console.ReadKey();
        }
    }
}
