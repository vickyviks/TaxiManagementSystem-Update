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
using System.Text.RegularExpressions;

namespace Capgemini.CustomerManagementSystem.BusinessLayer
{
    /// <summary>
    /// CustomerBL is class of business Logic Layer(BLL) which implement IcustomerBL interface.
    /// </summary>
    public class CustomerBL: IcustomerBL
    {

        //Creating object of customer data access Layer.
        CustomerDAL customerDAL = new CustomerDAL();
       
        /// <summary>
        /// Method to validate name of customer with the help of regex.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ValidateName(string str)
        {
            //Regex keyword to declare regex expression of only alphabet exists in this string parameter.
            Regex regex = new Regex(@"^[a-zA-Z ]+$");

            //If string param is match with regex pattern then it return true else false.
            return regex.IsMatch(str);
        }

        /// <summary>
        /// Method to validate city of customer with the help of regex.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ValidateCity(string str)
        {
            //Regex keyword to declare regex expression of only alphabet exists in this string parameter.
            Regex regex = new Regex(@"^[a-zA-Z ]+$");

            //If string param is match with regex pattern then it return true else false.
            return regex.IsMatch(str);
        }

        /// <summary>
        /// Method to validate phone number of customer with the help of regex.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ValidatePhone(string str)
        {
            //Regex keyword to declare regex expression that first digit of phon number must be between range 6-9 and other 9 numbers can lie between 0-9.
            Regex regex = new Regex(@"[6-9]{1}[0-9]{9}");

            //If string param is match with regex pattern then it return true else false.
            return regex.IsMatch(str);
        }

        /// <summary>
        /// Method to search customerID exists or not by passing ID to customer data access layer from where id is checked by collection or database.
        /// </summary>
        /// <param name="searchCustomerID"></param>
        /// <returns></returns>
        public Customer SearchCustomerBL(int searchCustomerID)
        {
            Customer searchCustomer = null;
            try
            {
                //Passing id to SearchCustomerDAL method of data access layer which check whether id exists or not.
                // If id exists then it returns that matching id object and that object is stored in searchCustomer
                searchCustomer = customerDAL.SearchCustomerDAL(searchCustomerID);
            }
            
            //To Catch the custom exception thrown from Data access layer and pass it to presentation layer by again throwing.
            catch (CustomerManagementException ex)
            {
                throw ex;
            }
            
            //To catch the exception thrown by SearchCustomerBL method.
            catch (Exception ex)
            {
                throw ex;
            }
            return searchCustomer;
        }

        /// <summary>
        /// This UpdateCustomerBL method call by presentation layer and it's work is to call the updatecustomer method of data access layer.
        /// </summary>
        /// <param name="updateCustomer"></param>
        /// <returns></returns>
        public bool UpdateCustomerBL(Customer updateCustomer)
        {
            bool customerUpdated = false;
            try
            {
                
                //Passing customer object i.e updatedcustomer to UpdateCustomerDAL method of data access layer which check whether object exists or not.
                // If object exists then it returns bool expression i.e if matching object is exists then true else false.
                customerUpdated = customerDAL.UpdateCustomerDAL(updateCustomer);
            }

            //To Catch the custom exception thrown from Data access layer and pass it to presentation layer by again throwing.
            catch (CustomerManagementException)
            {
                throw;
            }

            //To catch the exception thrown by UpdateCustomerBL method.
            catch (Exception ex)
            {
                throw ex;
            }

            return customerUpdated;
        }

        /// <summary>
        /// adminVerify method is to pass the input credentials that is sent from presentation layer to data access layer through business layer to check 
        /// whether they are correct or not.
        /// </summary>
        /// <param name="name">username</param>
        /// <param name="pass">password</param>
        /// <returns></returns>
        public static bool AdminVerify(string name,string pass)
        {
            try
            {
                bool adminVerified = false;

                

                //To send this credentails to adminverify method of CustomerDAL i.e customer data access layer. 
                adminVerified = CustomerDAL.AdminVerify(name, pass);
                return adminVerified;
            }
            catch(CustomerManagementException ex)
            {
                throw new CustomerManagementException(ex.Message);
            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}
