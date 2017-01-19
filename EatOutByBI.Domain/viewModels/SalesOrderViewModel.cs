using EatOutByBI.Data.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

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

        [DisplayName("Kundens Namn")]
        public string CustomerName { get; set; }
        //public string PONumber { get; set; }


        public int SeatID { get; set; }

        [DisplayName("Bordsplats")]
        public string SeatPlace { get; set; }


        public int EmployeeID { get; set; }

        [DisplayName("Kyparens Namn")]
        public string EmployeeName { get; set; }

        //public SelectList employees { get; set; }


        public int PaymentMethodId { get; set; }
        //public string PaymentMethodType { get; set; }

        [DisplayName("Tidpunkt")]
        public DateTime DateTime { get; set; }
        public string MessageToClient { get; set; }

        public ObjectState ObjectState { get; set; }

        public List<SalesOrderItemViewModel> SalesOrderItems { get; set; }


        public List<int> SalesOrderItemsToDelete { get; set; }
    }
}