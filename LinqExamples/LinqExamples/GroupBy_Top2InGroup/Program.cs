// See https://aka.ms/new-console-template for more information

/*
 * Goal: Find top 2 vendors by item for every customer. 
 * Result: Program prints list of customers with top 2 vendors for every item.
 */

using GroupBy_Top2InGroup;

var exampleList = ExampleCustomerTransactionsDTOHelper.CreateExampleList();
var result = from t in exampleList
             group t by new
             {
                 CustomerId = t.CustomerId,
                 CustomerName = t.CustomerName,
                 Item = t.ItemName,
                 Vendor = t.VendorName,
             } into g
             select new
             {
                 CustomerId = g.Key.CustomerId,
                 CustomerName = g.Key.CustomerName,
                 Item = g.Key.Item,
                 Vendor = g.Key.Vendor,
                 Cost = g.Sum(x => x.Quantity * x.Price),
             };
var resultList = result.ToList();

var resultWithGroupModel = from t in exampleList
                           group t by new GroupByModel
                           {
                               CustomerId = t.CustomerId,
                               CustomerName = t.CustomerName,
                               Item = t.ItemName,
                               Vendor = t.VendorName,
                           } into g
                           select new
                           {
                               CustomerId = g.Key.CustomerId,
                               CustomerName = g.Key.CustomerName,
                               Item = g.Key.Item,
                               Vendor = g.Key.Vendor,
                               Cost = g.Sum(x => x.Quantity * x.Price),
                           };
var resultWithGroupModelList = resultWithGroupModel.ToList();

Console.ReadLine();
