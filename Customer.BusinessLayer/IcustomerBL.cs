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
using Capgemini.CustomerManagementSystem.Entities;
using Capgemini.CustomerManagementSystem.DataAccessLayer;
using Capgemini.CustomerManagementSystem.Exceptions;

namespace Capgemini.CustomerManagementSystem.BusinessLayer
{
    /// <summary>
    /// Interface of customer business logic layer.
    /// </summary>
    interface IcustomerBL
    {
        /// <summary>
        /// Interface of Business Layer for UpdateCustomer Method.
        /// </summary>
        /// <param name="updateCustomer"></param>
        /// <returns></returns>
        bool UpdateCustomerBL(Customer updateCustomer);
    }
}
