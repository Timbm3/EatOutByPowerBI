using System;
using System.Linq;

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


            var newAdd2 = new Seat()
            {
                SeatID = 1,
                Bar = false,
                Outside = false,
                TableNr = 1
            };

            using (var ctx = new EatOutContext())
            {
                ctx.Database.Log = Console.WriteLine;
                ctx.Seats.Add(newAdd2);
                ctx.SaveChanges();

                Console.WriteLine(ctx.Products.Count());

                Console.ReadLine();
            }


        }
    }
}
