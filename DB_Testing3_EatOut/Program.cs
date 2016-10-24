using EatOutByBI.Data.Classes;
using System;
using System.Collections.Generic;

namespace EatOutByBI.Data
{
    class Program
    {
        static void Main(string[] args)
        {

            Order newAdd = new Order()
            {
                EmployeeID = 1,
                SeatID = 1,
                TimeTableID = 1,
                OrderRows = new List<OrderRow>()
    {
        new OrderRow() {ProductID = 1,Kvantitet = 3},
        new OrderRow() {ProductID = 2, Kvantitet = 2}
    }
            };


            TimeTable newAdd2 = new TimeTable()
            {
                MonthDay = 2,
                MonthName = "Februari",
                WeekDay = "Friday",
                Year = 2016,
                YearWeekNumber = 8,
                TimeStamp = 21,


            };



            using (var ctx = new EatOutContext())
            {
                ctx.Database.Log = Console.WriteLine;

                ctx.Orders.Add(newAdd);
                ctx.SaveChanges();

                Console.ReadKey();
            }


        }


    }
}

