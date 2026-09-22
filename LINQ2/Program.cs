using LINQ2.DataSources;
using LINQ2.Models;
using System.Collections;


namespace LINQ2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var PList = Source.ProductList;
            var CList = Source.CustomerList;

            #region Q1

            var expensive = PList.OrderByDescending(p => p.UnitPrice).Take(3);

            foreach (var p in expensive)
            {

                Console.WriteLine(p.ProductName);

            }

            #endregion

            #region Q2

            var page2 = PList.Skip(5).Take(5);
            Console.WriteLine("\n----- Page2 -----\n");

            foreach (var p in page2)
            {

                Console.WriteLine($"Product ID: {p.ProductID} Product Name: {p.ProductName}");

            }

            #endregion

            #region Q3

            var cheap = PList.OrderBy(p => p.UnitPrice).TakeWhile(p => p.UnitPrice < 25);
            Console.WriteLine("\n----- Cheap -----\n");

            foreach (var p in cheap)
            {

                Console.WriteLine($"Product Name: {p.ProductName} Product Price: {p.UnitPrice}");

            }



            #endregion

            #region Q4

            var checkInStock = PList.Where(p => p.Category == "Seafood").All(p => p.UnitsInStock > 0);
            Console.WriteLine("\n----- Check -----\n");

            Console.WriteLine($"All Seafood in stock? : {checkInStock}");
            #endregion

            #region Q5

            int[] ids = { 3, 9, 13, 18 };
            Console.WriteLine("\n----- Check ID -----\n");
            var checkID = ids.Any(id => id == 9);

            Console.WriteLine($"9? : {checkID}");
            #endregion

            #region Q6

            var GroupByCategoryCount = PList.GroupBy(p => p.Category);

            Console.WriteLine("\n----- Cats count -----\n");

            foreach (var group in GroupByCategoryCount)
            {
                Console.WriteLine(group.Count());
            }

            #endregion

            #region Q7

            var GroupByCategoryNames = PList.GroupBy(p => p.Category).Select(group => new
            {
                Category = group.Key,
                ProductNames = group.Select(p => p.ProductName)
            });

            Console.WriteLine("\n----- Grouped Names -----\n");

            foreach (var group in GroupByCategoryNames)
            {
                Console.WriteLine($"\n{group.Category}:\n");

                foreach (var name in group.ProductNames)
                {
                    Console.WriteLine(name);
                }

            }


            #endregion

            #region Q8

            var GroupBMoreThan3 = PList.GroupBy(p => p.Category).Where(g => g.Count() > 3);
            Console.WriteLine("\n----- GroupBMoreThan3  -----\n");

            foreach (var group in GroupBMoreThan3)
            {
                Console.WriteLine(group.Key);

            }
            #endregion

            #region Q9
            Console.WriteLine("\n----- customersByCountry  -----\n");

            var customersByCountry = from customer in CList
                                     group customer by customer.Country into CountryGroup
                                     select new
                                     {
                                         Country = CountryGroup.Key,
                                         Count = CountryGroup.Count(),
                                         TotalOrderValue = CountryGroup.Sum(c => c.Orders.Sum(o => o.Total))
                                     };


            foreach (var country in customersByCountry)
            {
                Console.WriteLine(
                    $"Country: {country.Country} | Count: {country.Count} | Total Order Value: {country.TotalOrderValue}"
                );
            }
            #endregion

            #region Q10

            var Stock = PList.Sum(p => p.UnitsInStock);

            Console.WriteLine("\n----- Stock  -----\n");

            Console.WriteLine(Stock);

            #endregion

            #region Q11
            Console.WriteLine("\n----- Cheapest vs Most Expensive  -----\n");

            var cheapest = PList.OrderBy(p => p.UnitPrice).First();
            var mostExpensive = PList.OrderByDescending(p => p.UnitPrice).First();

            Console.WriteLine($"Name: {cheapest.ProductName} Price: {cheapest.UnitPrice}");
            Console.WriteLine($"Name: {mostExpensive.ProductName} Price: {mostExpensive.UnitPrice}");

            #endregion

            #region Q12

            var distinct = PList.Select(p => p.Category).Distinct();
            Console.WriteLine("\n----- Distinct List  -----\n");


            foreach (var c in distinct)
            {
                Console.WriteLine($"Name: {c}");
            }


            #endregion

            #region Q13

            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };

            int[] setB = { 3, 6, 9, 12, 15, 13 };
            Console.WriteLine("\n----- Set A/B  -----\n");

            var BinA = setA.Except(setB);

            foreach (var n in BinA)
            {
                Console.WriteLine(n);
            }


            #endregion

            #region Q14

            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };

            Console.WriteLine("\n----- Set A/B  -----\n");

            var countries = list1.Except(list2, StringComparer.OrdinalIgnoreCase);

            foreach (var c in countries)
            {
                Console.WriteLine(c);
            }
            #endregion

            #region Q15

            var idDictionary = PList.ToDictionary(p => p.ProductID);
            Console.WriteLine("\n----- Dictionary -----\n");
            if (idDictionary.ContainsKey(18))
            {
                Console.WriteLine(idDictionary[18]);
            }

            #endregion

            #region Q16
            Console.WriteLine("\n----- Greater50 -----\n");
            var greaterThan50 = PList.First(p => p.UnitPrice > 50);

            Console.WriteLine(greaterThan50);
            #endregion

            #region Q17

            var over500 = PList.FirstOrDefault(p => p.UnitPrice > 500);

            Console.WriteLine("\n----- Product Over 500 -----\n");

            Console.WriteLine(over500);

            #endregion

            #region Q18

            var table = Enumerable.Range(1, 10).Select(x => x * 7);

            Console.WriteLine("\n----- Multiplication Table -----\n");

            foreach (var x in table)
            {
                Console.WriteLine(x);
            }

            #endregion

            #region Q19

            var evenNumbers = Enumerable.Range(1, 30).Where(x => x % 2 == 0);

            Console.WriteLine("\n----- Even Numbers -----\n");

            foreach (var x in evenNumbers)
            {
                Console.WriteLine(x);
            }

            #endregion

            #region Q20

            var names = PList.Take(3).Select(p => p.ProductName).Concat(CList.Take(3).Select(c => c.CompanyName));

            Console.WriteLine("\n----- Product + Customer Names -----\n");

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            #endregion

            #region Q21

            var paired = PList.Zip(CList, (product, customer) => new
            {
                Product = product.ProductName,
                Customer = customer.CompanyName
            });

            Console.WriteLine("\n----- Product + Customer -----\n");

            foreach (var pair in paired)
            {
                Console.WriteLine($"Product: {pair.Product} | Customer: {pair.Customer}");
            }

            #endregion

        }
    }
}

