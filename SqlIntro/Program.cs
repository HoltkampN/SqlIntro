using System;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            using (var conn = new MySqlConnection(connectionString))
            {
                var repo = new DapperDb(conn);

                foreach (var prod in repo.GetProducts())
                {
                    Console.WriteLine("Product Name: " + prod.Name + " Time: " + prod.Date.DayOfWeek);

                }

                repo.DeleteProduct(500);

                repo.InsertProduct(new Product
                {
                    Name = "Superb",
                    Color = "Orange",
                    Date = new DateTime(2000, 10, 22),
                    ListPrice = 3.00,
                    ProductNumber = "2bornot2b",
                    SellStartDate = new DateTime(2000, 10, 22),
                    SafetyStockLevel = 3,
                    DaysToManufacture = 4,
                    FinishedGoodsFlag = true,
                    ModifiedDate = new DateTime(2000, 10, 22),
                    MakeFlag = false,
                    ReorderPoint = 77,
                    StandardCost = 5,
                });

                repo.UpdateProduct(new Product { ProductId = 1, Name = "Superb" });
                Console.ReadLine();
            }

            
        }


    }
}
}
