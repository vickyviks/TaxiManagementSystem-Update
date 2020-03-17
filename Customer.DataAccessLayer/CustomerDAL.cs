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
using System.Data;
using System.Data.Common;
using Capgemini.CustomerManagementSystem.Entities;
using Capgemini.CustomerManagementSystem.Exceptions;
using System.IO;
using System.Xml.Serialization;

namespace Capgemini.CustomerManagementSystem.DataAccessLayer
{
    /// <summary>
    /// CustomerDL is class of Data Access Layer(DAL) which implement ICustomerDL interface.
    /// </summary>
    public class CustomerDAL: ICustomerDL
    {
        /// <summary>
        ///CustomerList is Generic list of Customer type to store customer objects in collection. 
        /// </summary>
        public static List<Customer> customerList = new List<Customer>(); 
        
        /// <summary>
        /// This is static constructor to deserialize the file whenever the data access layer is called.
        /// </summary>
        static CustomerDAL()
        {
            try
            {
                string Path = @"C:\Users\vipul\Downloads\Vipul_Pareta\Sprint_1\vipul.xml";
                if(File.Exists(Path))
                {
                    //Using filestream to open the xml file in read mode.
                    FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read);
                    //declare xmlserializer of generic list customer type.
                    XmlSerializer xs = new XmlSerializer(typeof(List<Customer>));

                    //Deserialize the xml file using xmlserializer and store it into Customerlist.
                    customerList = (List<Customer>)xs.Deserialize(fs);

                    //To close the file otherwise it give unhandled exception that it can't able to perform operation on already opened file.
                    fs.Close();
                }
                else
                {
                    throw new CustomerManagementException($"File not found on location {Path}.");
                }
                
                

               
            }
            catch(CustomerManagementException ex)
            {
                throw ex;
            }
            
        }
       
        /// <summary>
        /// SearchCustomerDAL method of data access layer to check the customerid in generic customerlist and returns object of that matching id if exists.
        /// </summary>
        /// <param name="searchCustomerID"></param>
        /// <returns></returns>
        public Customer SearchCustomerDAL(int searchCustomerID)
        {
            Customer searchCustomer = null;
            try
            {
                //Applying find method of generic customerList which returns object if the condition inside it's scope satisfied using lambda expression.
                searchCustomer = customerList.Find(Customer => Customer.customerId == searchCustomerID);
            }

            //During try if system throws any exception then it catches that exception in SystemException.
            catch (SystemException ex)
            {
                //After catching it again throw that exception to business logic layer by converting it to a custom exception. 
                throw new CustomerManagementException(ex.Message);
            }
            return searchCustomer;
        }

        /// <summary>
        /// UpdateCustomerDAL is the method of data access layer to update the data present in file and then serialize the file.
        /// </summary>
        /// <param name="updateCustomer"></param>
        /// <returns></returns>
        public bool UpdateCustomerDAL(Customer updateCustomer)
        {
            bool customerUpdated = false;
            try
            {
                //Alternative method:-
                //Customer obj=CustomerList.find(Customer=>Customer.id==updateCustomer.customerId)
                //obj.customerName=updateCustomer.customerName.

                //for loop to iterate through every object present in the list.
                for (int i = 0; i < customerList.Count; i++)
                {

                    //if condition to execute whenever it find that id which is present in param updatecustomer i.e object of customer type come from BLL.
                    if (customerList[i].customerId == updateCustomer.customerId)
                    {
                        //updating customer name.
                        customerList[i].customerName= updateCustomer.customerName;

                        //updating customer city.
                        customerList[i].city= updateCustomer.city;
                        
                        //updating customer age.
                        customerList[i].age= updateCustomer.age;

                        //updating customer phone number.
                        customerList[i].phone= updateCustomer.phone;

                        //updating customer pinCode.
                        customerList[i].pincode= updateCustomer.pincode;
                        
                        //Customer is updated.
                        customerUpdated = true;

                        //Filestream to open the file and update the details inside the file by serializing it in a particular format.
                        FileStream fs = new FileStream(@"C:\Users\vipul\Downloads\Vipul_Pareta\Sprint_1\vipul.xml", FileMode.Open, FileAccess.Write);
                        
                        //XmlSerializer to serialize the file in xmlformat.
                        XmlSerializer xs = new XmlSerializer(typeof(List<Customer>));
                        
                        //File is serializing and it take two argument:-
                        //1.File 2.List where updated data is present.
                        xs.Serialize(fs, customerList);
  
                        //After serializing the file use fs.close to close the file.
                        fs.Close();
                    }
                }
            }

            //During try if system throws any exception then it catches that exception in SystemException.
            catch (SystemException ex)
            {
                //After catching it again throw that exception to business logic layer by converting it to a custom exception.
                throw new CustomerManagementException(ex.Message);
            }

            //it return boolean expression that customer is updated or not.
            return customerUpdated;
        }

        /// <summary>
        /// adminverify method of data access layer to verify the credentials coming from BLL with the credentials present in Admin Entity.
        /// </summary>
        /// <param name="uname">username</param>
        /// <param name="pass">password</param>
        /// <returns></returns>
        public static bool AdminVerify(string uname,string pass)
        {

            //if condition to check whether credentials are matching or not with the credentials present inside Admin Entity.
            if(Admin.username==uname && Admin.password==pass)
            {
                //if credentials are correct then it returns true.
                return true;
            }
            //else false.
            return false;

        }
    }
}
