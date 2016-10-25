using EatOutByBI.Data.Classes;
using System;
using System.Collections.Generic;

namespace EatOutByBI.Data
{
    class Program
    {
        static void Main(string[] args)
        {

            Order newAdd1 = new Order()
            {
                EmployeeID = 1,
                SeatID = 1,
                TimeTableID = 1,
                OrderRows = new List<OrderRow>()
    {
        new OrderRow() {ProductID = 1,Kvantitet = 3}
    }
            };

            using (var ctx = new EatOutContext())
            {
                ctx.Database.Log = Console.WriteLine;

                ctx.Orders.Add(newAdd1);
                ctx.SaveChanges();

                
            }


        }


    }
}

