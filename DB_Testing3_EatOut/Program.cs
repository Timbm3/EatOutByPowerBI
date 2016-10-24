using System;
using System.Collections.Generic;
using EatOutByBI.Data.Classes;

namespace EatOutByBI.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            //DrickadDev
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
                Seat nySeat = new Seat()
                {
                    SeatID = 12,
                    TableNr = 4,
                    Outside = false,
                    Bar = false
                };

                ctx.Seats.Add(nySeat);
                ctx.SaveChanges();
                Console.WriteLine(nySeat.SeatID);
            }

            using (var ctx = new EatOutContext())
            {
                Order nyOrder = new Order()
                {
                    OrderID = 123,
                    EmployeeID = 123,
                    SeatID = 123,
                    TimeTableID = 123,
                    Seat = new Seat()
                    {
                        SeatID = 123,
                        Outside = true
                    },
                    TimeTable = new TimeTable()
                    {
                        TimeTableID = 123,
                        Year = 2016,
                        YearWeekNumber = 1
                    },
                    Employee = new Employee()
                    {
                        EmployeeID = 123,
                        EmployeeFormID = 123,
                        EmployeeTypeID = 123,
                        Name = "Kalle",
                        EmployeeForm = new EmployeeForm()
                        {
                            EmployeeFormID = 123,
                            EmployeeFormName = "Heltid",

                        },
                        EmployeeType = new EmployeeType()
                        {
                            EmployeeTypeID = 123,
                            EmployeeTypeName = "Servitör"
                        }
                    },
                    OrderRows = new List<OrderRow>()
                    {
                        new OrderRow()
                        {
                            OrderID = 123,
                            OrderRowID = 123,

                            Product = new List<Product>()
                            {
                                new Product()
                                {
                                    ProductID = 123,
                                    ProductName = "Tuborg",
                                    ProductType = new ProductType()
                                    {
                                        ProductTypeID = 123,
                                        ProductTypeName = "Öl"

                                    },
                                    ProductGroup = new ProductGroup()
                                    {
                                        ProductGroupID = 123,
                                        ProductGroupName = "Dryck"
                                    }
                                }

                            }

                        }
                    }
                };

                Seat nySeat = new Seat()
                {
                    SeatID = 1,
                    Bar = true
                };

                ProductType nyGroup = new ProductType()
                {
                    ProductTypeID = 23,
                    ProductTypeName = "Lunch"
                };

                ctx.Database.Log = Console.WriteLine;

                ctx.ProductTypes.Add(nyGroup);
                ctx.SaveChanges();
                Console.WriteLine(nyGroup.ProductTypeID);


                //ctx.Products.Add(newAdd);
                //ctx.SaveChanges();

                //Console.WriteLine(ctx.Products.Count());

                //Console.ReadLine();
            }


        }
    }
}

