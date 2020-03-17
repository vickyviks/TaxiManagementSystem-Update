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
using Capgemini.CustomerManagementSystem.Exceptions;

namespace Capgemini.CustomerManagementSystem.DataAccessLayer
{
    /// <summary>
    /// Interface of customer data access layer.
    /// </summary>
    interface ICustomerDL
    {
        /// <summary>
        /// Interface of DataAccessLayer For updateCustomer method.
        /// </summary>
        /// <param name="updateCustomer"></param>
        /// <returns></returns>
        bool UpdateCustomerDAL(Customer updateCustomer);
    }
}
