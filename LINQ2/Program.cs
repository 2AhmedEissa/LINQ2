using LINQ2.DataSources;


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




            #endregion

            #region Q5




            #endregion

            #region Q6



            #endregion

            #region Q7


            #endregion

            #region Q8


            #endregion

            #region Q10

            #endregion

            #region Q11




            #endregion

            #region Q12

            #endregion
            #region Q13

            #endregion
            #region Q14

            #endregion
            #region Q15

            #endregion
            #region Q16

            #endregion
            #region Q17

            #endregion
            #region Q18

            #endregion
            #region Q19

            #endregion
            #region Q20

            #endregion
            #region Q21

            #endregion

        }
    }
}

