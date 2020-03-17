//CaseStudy name:- Customer Management System
//Developer:- Vipul Pareta
//Task:- Update customer
//Created:- 05/02/2020
//Modified:- 07/02/2020
using System;
using System.Collections.Generic;
using System.Text;
using Capgemini.CustomerManagementSystem.Entities;
using Capgemini.CustomerManagementSystem.BusinessLayer;
using Capgemini.CustomerManagementSystem.Exceptions;
using System.IO;
using System.Text.RegularExpressions;

namespace Capgemini.CustomerManagementSystem.PresentationLayer
{
    /// <summary>
    /// Main Program.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Calling the top layer to print developer details.
            TopLayer();
            
            
            // Condition to verify admin credentials.
            while (!AdminVerify())
            {
                Console.WriteLine("\n###### Invalid Credentials ########");
            }
            Console.Clear();

            //choice to take any kind of input from the user.
            string choice;
            do
            {
                //Call the console Menu to update and exit.
                PrintMenu();
               
                //choice2 input is for taking the valid input.
                int choice2;
                Console.WriteLine("Enter your Choice:");
                choice = Console.ReadLine();
                
                // Using TryParse so if user type anything whether it matches with datatype or not the program did not crash.
                bool x = int.TryParse(choice, out choice2);
                
                if (x)
                {
                    switch (choice2)
                    {
                        case 1:
                            //Calling the update customer method.
                            UpdateCustomer();
                            break;
                        case 2:
                            //Exit
                            return;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                else
                {
                    // If the choice of user is invalid and not convertable in string then tryParse return false and else loop execute where continue
                    // again run the program by writing "Invalid choice".
                    Console.WriteLine("Invalid Choice");
                    
                }
            } while (choice != null);  
        }
        /// <summary>
        /// Method To Update Customer Details.
        /// </summary>
        public static void UpdateCustomer()
        {
            try
            {
                //To take the final input of id after validation.
                int updateCustomerID;
                
                //To take the valid input of id  in "id" field that passes convertable test case of TryParse.
                int id;
                
                //var is used in "input_id" field to take any kind of input from user.
                Console.WriteLine("Enter CustomerID to Update Details:");
                var input_Id = Console.ReadLine();

                //Applying 2 conditions on while loop which help in not crashing the program:-
                //1. when user does not enter any input and hit the enter button then String.ISNullorEmpty catches it.
                //2. when user enter any string data in integer id and that's not possible so we use tryparse with not.
                while (string.IsNullOrEmpty(input_Id) || !int.TryParse(input_Id, out id))
                {
                    
                    Console.WriteLine("Invalid, please enter valid id ");
                    Console.WriteLine("** Hint: ID should be numeric and only 3 id available in data.** ");
                    input_Id = Console.ReadLine();
                }
                //final id after passing tryparse stored in "updateCustomerID".
                updateCustomerID = id;


                //Sending customerid to SearchCutomerBL method of Business class i.e CustomerBL to check whether customer exists or not
                // and if exists it returns that customer object. 
                CustomerBL updated = new CustomerBL();
                Customer updatedCustomer = updated.SearchCustomerBL(updateCustomerID);
                
                
                // IF the customer object that is returned from SearchCustomerBL is not null then it ask for updated details.
                  if (updated != null)
                {
                    //var is used in "input_n" field to take any kind of input from user.
                    Console.WriteLine("Update Customer Name :");                
                    var input_n = Console.ReadLine();

                    //Applying 2 conditions on while loop which help in not crashing the program:-
                    //1. when user does not enter any input and hit the enter button then String.ISNullorEmpty catches it.
                    //2. when user enter any int data or invalid data in input_n and that's not possible so in this case 
                    // we Validate the data in Business Layer with not.
                    while (string.IsNullOrEmpty(input_n) || !CustomerBL.ValidateName(input_n))
                    {
                        Console.WriteLine("Invalid, please enter valid name");
                        Console.WriteLine("**Hint: name consists of alphabets only.**");
                        input_n = Console.ReadLine();
                    }
                    updatedCustomer.customerName = input_n;


                    //var is used in "input_c" field to take any kind of input from user.
                    Console.WriteLine("Update Customer city:");
                    var input_c = Console.ReadLine();

                    //Applying 2 conditions on while loop which help in not crashing the program:-
                    //1. when user does not enter any input and hit the enter button then String.ISNullorEmpty catches it.
                    //2. when user enter any int data or invalid data in input_c and that's not possible so in this case 
                    // we Validate the data in Business Layer with not.
                    while (string.IsNullOrEmpty(input_c) || !CustomerBL.ValidateCity(input_c))
                    {
                        Console.WriteLine("Invalid, please enter valid city");
                        Console.WriteLine("**Hint: city consists of alphabets only.** ");
                        input_c = Console.ReadLine();
                    }
                    updatedCustomer.city = input_c;


                    //var is used in "input_a" field to take any kind of input from user.
                    Console.WriteLine("Update Customer Age:");
                    var input_a = Console.ReadLine();
                    int age;
                    
                    //Applying 4 conditions on while loop which help in not crashing the program:-
                    //1. when user does not enter any input and hit the enter button then String.ISNullorEmpty catches it.
                    //2. when user enter any string data in integer id and that's not possible so we use tryparse with not.
                    //3. Entered age as a positive integer.
                    //4. Entered age not greater than 100;
                    while (string.IsNullOrEmpty(input_a) || !int.TryParse(input_a, out age) || age <= 0 || age > 100)
                    {
                        Console.WriteLine("Invalid, plz enter valid age");
                        Console.WriteLine("**Hint: age should be numeric only and lie in range (1-100).**");
                        input_a = Console.ReadLine();
                    }
                    updatedCustomer.age = age;



                    //var is used in "input_ph" field to take any kind of input from user.
                    Console.WriteLine("Update Customer Phone:");
                    var input_ph = Console.ReadLine();

                    //Applying 2 conditions on while loop which help in not crashing the program:-
                    //1. when user does not enter any input and hit the enter button then String.ISNullorEmpty catches it.
                    //2. when user enter invalid data in input_ph and that's not possible so in this case 
                    // we Validate the data in Business Layer with not.
                    while (string.IsNullOrEmpty(input_ph) || !CustomerBL.ValidatePhone(input_ph) || input_ph.ToString().Length != 10)
                    {
                        Console.WriteLine("Invalid, plz enter valid phone number");
                        Console.WriteLine("**Hint: Phone number must be numeric only and of 10 digits in which first digit must be between 6-9.**");
                        input_ph = Console.ReadLine();
                    }
                    updatedCustomer.phone = input_ph;


                    //var is used in "input_pi" field to take any kind of input from user.
                    Console.WriteLine("Update Customer pincode:");
                    var input_pi = Console.ReadLine();
                    int pin;

                    //Applying 2 conditions on while loop which help in not crashing the program:-
                    //1. when user does not enter any input and hit the enter button then String.ISNullorEmpty catches it.
                    //2. when user enter invalid data in input_pi and that's not possible so in this case 
                    // we Validate the data in Business Layer with not.
                    //3. To check Whether the length of pincode is 6 digit or not.
                    while (string.IsNullOrEmpty(input_pi) || !int.TryParse(input_pi, out pin) || pin.ToString().Length != 6)
                    {
                        Console.WriteLine("Invalid, please enter 6 digit Valid Pincode");
                        Console.WriteLine("**Hint: Pincode is numeric only and consists of 6 digit only.** ");
                        input_pi = Console.ReadLine();
                    }
                    updatedCustomer.pincode = input_pi;

                   
                    //Creating object of customer business layer to call updateCustomerBL method in it.
                    CustomerBL C_bl = new CustomerBL();
                    
                    //Calling bool updatecustomerBL method of customer business layer which return a boolean expression that customer is updated or not.
                    bool CustomerUpdated = C_bl.UpdateCustomerBL(updatedCustomer);
                    
                    //If customerUpdated get true then the if loop execute otherwise else loop.
                    if (CustomerUpdated)
                        Console.WriteLine("######################### Customer Details Updated ###########################");
                    else
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!! Customer Details not Updated !!!!!!!!!!!!!!!!!!!!!");
                }

                // If customerID not match with the data inside the file then this else loop get executed.
                else
                {
                    Console.WriteLine("No Customer Details Available");
                    UpdateCustomer();
                }


            }
            //It catch the user-defined or custom exception that is thrown from business layer.
            catch (CustomerManagementException ex)
            {
                //Display whatever the message is contained by exception that is thrown from business layer while validating.
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// adminVerify is a bool method to verify admin credentials with the credentials that is input by user.
        /// </summary>
        /// <returns></returns>
        public static bool AdminVerify()
        {
            bool adminVerified = false;
            try
            {

                Console.WriteLine("\t\t\t\t********************* Login Credentials *************************");
                Console.WriteLine("**Hint:- for username and password go into Capgemini.CustomerManagementSystem.Entity project and Find username and password in adminverify method of CustomerEntity class.");
                Console.WriteLine("\nEnter Username:");
                string uname = Console.ReadLine();
                Console.WriteLine("\nEnter Password:");
                string pass = Console.ReadLine();
                adminVerified = CustomerBL.AdminVerify(uname, pass);

            }
            catch (CustomerManagementException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                AdminVerify();
            }
            return adminVerified;
        }
        /// <summary>
        /// Method to show the console MENU.
        /// </summary>
        private static void PrintMenu()
        {
            Console.WriteLine("\t\t\t\t" + "********** Welcome To Customer Management System************");
            Console.WriteLine("1. Update customer");
            Console.WriteLine("2. Exit");
            Console.WriteLine("******************************************\n");
        }
        /// <summary>
        /// This layer is to show developer details on screen
        /// </summary>
        private static void TopLayer()
        {
            Console.WriteLine("\t\t\t\t********************* Customer Management System ************************");
            Console.WriteLine("Developer:- VIPUL PARETA");
            Console.WriteLine("Task:- UPDATE CUSTOMER\n\n");
            
        }
    }
}




















