using System;
using System.Collections.Generic;
using System.Linq;

namespace DB_Testing3_EatOut
{
    class Program
    {
        static void Main(string[] args)
        {
            //        //DrickadDevytutyu
            //        //Middag
            //        //Snacks

            //        //Öl, Vin, sprit, förrätt, middag, efterrätt, Jordnötter, tillbehör
            Order nyOrder = new Order()
            {
                OrderID = 1,
                Seat = new Seat()
                {
                    SeatID = 1,
                    Outside = true
                },
                TimeTable = new TimeTable()
                {
                    TimeTableID = 1,
                    Year = 2016,
                    YearWeekNumber = 1
                },
                Employee = new Employee()
                {
                    EmployeeID = 1,
                    Name = "Kalle",
                    EmployeeForm = new EmployeeForm()
                    {
                        EmployeeFormID = 1,
                        EmployeeFormName = "Heltid",

                    },
                    EmployeeType = new EmployeeType()
                    {
                        EmployeeTypeID = 1,
                        EmployeeTypeName = "Servitör"
                    }
                },
                  OrderRows = new List<OrderRow>()
                {
new OrderRow()
{
    OrderRowID = 2,
    Product = new List<Product>()
    {
        new Product()
        {
            ProductName = "Carlsberg",
            ProductType = new ProductType()
            {
                ProductTypeName = "Middag"
            },
           ProductGroup = new ProductGroup()
           {
               ProductGroupName = "Middag"
           }
        }
    }
}
                        }

    };

                    using (var ctx = new EatOutContext())
                    {
                        ctx.Database.Log = Console.WriteLine;
                        ctx.Orders.Add(nyOrder);
                        ctx.SaveChanges();

                        Console.WriteLine(ctx.Products.Count());

                        Console.ReadLine();
                    }


        }
    }
}
