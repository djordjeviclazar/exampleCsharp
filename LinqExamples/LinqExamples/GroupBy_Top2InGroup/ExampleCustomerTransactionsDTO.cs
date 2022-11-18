using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupBy_Top2InGroup
{
    public class ExampleCustomerTransactionsDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ItemName { get; set; }
        public string VendorName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class ExampleCustomerTransactionsDTOHelper
    {
        public static List<ExampleCustomerTransactionsDTO> CreateExampleList()
        {
            List<ExampleCustomerTransactionsDTO> exampleList = new List<ExampleCustomerTransactionsDTO> 
            { 
                new ExampleCustomerTransactionsDTO
                {
                    CustomerId = 1,
                    CustomerName = "Lazar",
                    ItemName = "Hleb",
                    VendorName = "Žitopek",
                    Quantity = 2,
                    Price = 45,
                },
                new ExampleCustomerTransactionsDTO
                {
                    CustomerId = 1,
                    CustomerName = "Lazar",
                    ItemName = "Hleb",
                    VendorName = "Žitopek",
                    Quantity = 2,
                    Price = 45,
                },
                new ExampleCustomerTransactionsDTO
                {
                    CustomerId = 1,
                    CustomerName = "Lazar",
                    ItemName = "Mleko",
                    VendorName = "Imlek",
                    Quantity = 2,
                    Price = 150,
                },
                new ExampleCustomerTransactionsDTO
                {
                    CustomerId = 1,
                    CustomerName = "Lazar",
                    ItemName = "Mleko",
                    VendorName = "Megle",
                    Quantity = 2,
                    Price = 150,
                },
                new ExampleCustomerTransactionsDTO
                {
                    CustomerId = 1,
                    CustomerName = "Lazar",
                    ItemName = "Mleko",
                    VendorName = "ČovekSaLinkedIn",
                    Quantity = 10,
                    Price = 70,
                },
                new ExampleCustomerTransactionsDTO
                {
                    CustomerId = 2,
                    CustomerName = "Paja",
                    ItemName = "Nutela",
                    VendorName = "DeutchlandInFrance",
                    Quantity = 1,
                    Price = 700,
                },
                new ExampleCustomerTransactionsDTO
                {
                    CustomerId = 2,
                    CustomerName = "Paja",
                    ItemName = "Supa",
                    VendorName = "Maggi",
                    Quantity = 2,
                    Price = 150,
                },
                new ExampleCustomerTransactionsDTO
                {
                    CustomerId = 2,
                    CustomerName = "Paja",
                    ItemName = "Supa",
                    VendorName = "Maggi",
                    Quantity = 2,
                    Price = 250,
                },
                new ExampleCustomerTransactionsDTO
                {
                    CustomerId = 2,
                    CustomerName = "Paja",
                    ItemName = "Supa",
                    VendorName = "La KPlus",
                    Quantity = 2,
                    Price = 120,
                },
                new ExampleCustomerTransactionsDTO
                {
                    CustomerId = 2,
                    CustomerName = "Paja",
                    ItemName = "Supa",
                    VendorName = "La C",
                    Quantity = 1,
                    Price = 150,
                },
            };

            return exampleList;
        }
    }

    public class GroupByModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Item { get; set; }
        public string Vendor { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            var other = obj as GroupByModel;
            return this.CustomerId == other.CustomerId 
                        && this.CustomerName == other.CustomerName 
                        && this.Item == other.Item
                        && this.Vendor == other.Vendor;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            return CustomerId.GetHashCode();
        }
    }
}
