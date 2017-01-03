using EatOutByBI.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EatOutByBI.Domain.viewModels
{
    public class SalesOrderViewModel : IObjectWithState
    {
        public SalesOrderViewModel()
        {
            SalesOrderItems = new List<SalesOrderItemViewModel>();
            SalesOrderItemsToDelete = new List<int>();
        }
        public int SalesOrderId { get; set; }
        public string CustomerName { get; set; }
        //public string PONumber { get; set; }


        public int SeatId { get; set; }
        public string SeatPlace { get; set; }


        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }


        public int PaymentMethodId { get; set; }
        // public string PaymentMethodType { get; set; }


        public DateTime DateTime { get; set; }
        public string MessageToClient { get; set; }

        public ObjectState ObjectState { get; set; }

        public List<SalesOrderItemViewModel> SalesOrderItems { get; set; }


        public List<int> SalesOrderItemsToDelete { get; set; }
    }
}