using EatOutByBI.Data.Classes;
using System.Collections.Generic;

namespace EatOutByBI.Data.DTO
{
    public class OrderDTO
    {

        public OrderDTO()
        {
            OrderRows = new HashSet<SalesOrderItem>();
        }

        public int OrderID { get; set; }


        public int SeatID { get; set; }
        public IEnumerable<Seat> Seats { get; set; }


        public IEnumerable<OrderRowDTO> OrderRowDtos { get; set; }
        public IEnumerable<SalesOrderItem> OrderRows { get; set; }

        public Product Product { get; set; }
        public string ProduktNamn { get; set; }
        public int Kvantitet { get; set; }


        public int EmployeeID { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public int TimeTableID { get; set; }

    }
}
