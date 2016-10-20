﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Testing3_EatOut.Interfaces;

namespace DB_Testing3_EatOut
{
    public class EmployeeForm : IModificationHistory
    {
        public int EmployeeFormID { get; set; }
        public string EmployeeFormName { get; set; }
        public int EmployeeFormOrderRow { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        

    }
}
