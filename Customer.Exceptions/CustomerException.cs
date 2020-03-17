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

namespace Capgemini.CustomerManagementSystem.Exceptions
{
    /// <summary>
    /// CustomerManagementException is the custom exception or user-defined exception that inherit exception base class.
    /// </summary>
    public class CustomerManagementException:Exception
    {
        //Parameterless CustomerManagementException.
        /// <summary>
        /// Parameterless CustomerManagementException.
        /// </summary>
        public CustomerManagementException():base()
        {

        }

        /// <summary>
        /// CustomerManagementException with string message parameter.
        /// </summary>
        /// <param name="message"></param>
        public CustomerManagementException(string message) : base(message)
        {

        }

        /// <summary>
        /// CustomerManagementException with String message and innerException parameters.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public CustomerManagementException(string message,Exception innerException) : base(message,innerException)
        {

        }

    }
}
