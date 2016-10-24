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

            //using (var ctx = new EatOutContext())
            //{
            //    Order nyOrder = new Order()
            //    {
            //        OrderID = 1,
            //        EmployeeID = 1,
            //        SeatID = 1,
            //        TimeTableID = 1,
            //        Seat = new Seat()
            //        {
            //            SeatID = 1,
            //            Outside = true
            //        },
            //        TimeTable = new TimeTable()
            //        {
            //            TimeTableID = 1,
            //            Year = 2016,
            //            YearWeekNumber = 1
            //        },
            //        Employee = new Employee()
            //        {
            //            EmployeeID = 1,
            //            EmployeeFormID = 1,
            //            EmployeeTypeID = 1,
            //            Name = "Kalle",
            //            EmployeeForm = new EmployeeForm()
            //            {
            //                EmployeeFormID = 1,
            //                EmployeeFormName = "Heltid",

            //            },
            //            EmployeeType = new EmployeeType()
            //            {
            //                EmployeeTypeID = 1,
            //                EmployeeTypeName = "Servitör"
            //            }
            //        },
            //        OrderRows = new List<OrderRow>()
            //        {
            //            new OrderRow()
            //            {
            //                OrderID = 1,
            //                OrderRowID = 1,
            //                ProductID = 1,
            //                Product = new Product()
            //                {
            //                    ProductID = 1,
            //                    ProductTypeID = 1,
            //                    ProductGroupID = 1,
            //                    ProductName = "Köttbullar",
            //                    ProductType = new ProductType()
            //                    {
            //                        ProductTypeID = 1,
            //                        ProductTypeName = "Middag"
            //                    },
            //                    ProductGroup =  new ProductGroup()
            //                    {
            //                        ProductGroupID = 1,
            //                        ProductGroupName = "Mat"
            //                    }

            //                }
            //            }
            //        }
            //    };

            //Seat nySeat = new Seat()
            //{
            //    SeatID = 1,
            //    Bar = true
            //};

            //ctx.Seats.Add(nySeat);
            //ctx.SaveChanges();
            //Console.WriteLine(nyOrder.Seat.DateCreated);

            //ctx.Database.Log = Console.WriteLine;
            //ctx.Products.Add(newAdd);
            //ctx.SaveChanges();

            //Console.WriteLine(ctx.Products.Count());

            //Console.ReadLine();
        }


    }
}

