using EatOutByBI.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EatOutByBI.Domain.viewModels
{
    public class SalesOrderItemViewModel : IObjectWithState
    {
        //public SalesOrderItemViewModel()
        //{
        //    Products = new List<Product>();
        //}

        public int SalesOrderItemId { get; set; }
        // public string ProductCode { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
        //public decimal UnitPrice { get; set; }

        public int SalesOrderId { get; set; }

        //public List<Product> Products { get; set; }


        public ObjectState ObjectState { get; set; }
    }
}