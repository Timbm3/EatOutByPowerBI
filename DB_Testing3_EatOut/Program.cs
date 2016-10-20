using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Testing3_EatOut
{
    class Program
    {
        static void Main(string[] args)
        {
            //DrickadDevytutyu
            //Middag
            //Snacks

            //Öl, Vin, sprit, förrätt, middag, efterrätt, Jordnötter, tillbehör
            var newAdd = new Product()
            {
ProductName = "Lax",
ProductTypeID = 1,
ProductGroupID = 1,

            };

            using (var ctx = new EatOutContext())
            {
                ctx.Database.Log = Console.WriteLine;
                ctx.Products.Add(newAdd);
                ctx.SaveChanges();

                Console.WriteLine(ctx.Products.Count());

                Console.ReadLine();
            }


        }
    }
}
