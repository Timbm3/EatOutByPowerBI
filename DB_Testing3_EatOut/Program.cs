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
                
                Order nyOrder = new Order()
                {
                    OrderID = 2,
                    EmployeeID = 2,
                    SeatID = 2,
                    TimeTableID = 2,
                    Seat = new Seat()
                    {
                        SeatID = 2,
                        Outside = true
                    },
                    TimeTable = new TimeTable()
                    {
                        TimeTableID = 2,
                        Year = 2016,
                        YearWeekNumber = 1
                    },
                    Employee = new Employee()
                    {
                        EmployeeID = 2,
                        EmployeeFormID = 2,
                        EmployeeTypeID = 2,
                        Name = "Kalle",
                        EmployeeForm = new EmployeeForm()
                        {
                            EmployeeFormID = 2,
                            EmployeeFormName = "Heltid",

                        },
                        EmployeeType = new EmployeeType()
                        {
                            EmployeeTypeID = 2,
                            EmployeeTypeName = "Servitör"
                        }
                    },
                    OrderRows = new List<OrderRow>()
                    {
                        new OrderRow()
                        {
                            OrderID = 2,
                            OrderRowID = 2,
                            Product = new List<Product>()
                            {
                                new Product() { 
                                ProductID = 2,
                                ProductTypeID = 2,
                                ProductGroupID = 2,
                                ProductName = "Köttbullar",
                                ProductType = new ProductType()
                                {
                                    ProductTypeID = 2,
                                    ProductTypeName = "Middag"
                                },
                                ProductGroup =  new ProductGroup()
                                {
                                    ProductGroupID = 2,
                                    ProductGroupName = "Mat"
                                }
                                }
                            }
                        }
                    }
                };

                    ctx.Orders.Add(nyOrder);
                    ctx.SaveChanges();
                

                Seat nySeat = new Seat()
                {
                    SeatID = 1,
                    Bar = true
                };

                ctx.Database.Log = Console.WriteLine;


                //ctx.Products.Add(newAdd);
                //ctx.SaveChanges();

                //Console.WriteLine(ctx.Products.Count());

                //Console.ReadLine();
            }


        }
    }
}
