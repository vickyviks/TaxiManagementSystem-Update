//CaseStudy name:- Customer Management System
//Developer:- Vipul Pareta
//Task:- Update customer
//Created:- 05/02/2020
//Modified:- 07/02/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.CustomerManagementSystem.Entities
{
    /// <summary>
    /// Customer class consists of customerID,customerName,city,age,phone and pincode fields of customer.
    /// </summary>
    public class Customer
    {
        //CustomerId to take id of customer.
        private int _customerId;
        public int customerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        //CustomerName to take name of customer.
        private string _customerName;
        public string customerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        //City to take city of customer.
        private string _city;
        public string city
        {
            get { return _city; }
            set { _city = value; }
        }

        //age to take age of customer.
        private int _age;
        public int age
        {
            get { return _age; }
            set { _age = value; }
        }

        //phone to take phone-number of customer.
        private string _phone;
        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        //pincode to take pincode of customer.
        private string _pincode;
        public string pincode
        {
            get { return _pincode; }
            set { _pincode = value; }
        }

        //parameterless constructor to initiate the fields to it's default value.
        public Customer()
        {
            customerId = 0;
            customerName = string.Empty;
            city = string.Empty;
            age = 0;
            phone = null;
            pincode = null;
        }

    }
    
    //Admin class to verify admin credentials in data access layer.
    public class Admin
    {
        public static string username = "vipul";
        public static string password = "vip123";
    }
}