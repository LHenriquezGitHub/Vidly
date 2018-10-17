using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{


    public class CustomerViewModel
    {
        private List<Customer> _Customers;
        public List<Customer> Customers
        {
            get { return _Customers; }
            set {_Customers = value;}
        }
               
        private bool _IsCustomerListEmpty;
        public bool IsCustomerListEmpty {
            get { return _IsCustomerListEmpty; }
            set { _IsCustomerListEmpty = value;  }
        }
        private bool _IsSingleCustomerFound;
        public bool IsSingleCustomerFound
        {
            get { return _IsSingleCustomerFound; }
            set { _IsSingleCustomerFound = value; }
        }
        private bool _IsCustomersFound;
        public bool IsCustomersFound
        {
            get { return _IsCustomersFound; }
            set { _IsCustomersFound = value; }
        }

        public bool IsSingleCustomerNotFound { get; set; }
    }
}