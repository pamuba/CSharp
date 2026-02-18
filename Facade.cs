using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static DesignPatternDemos.Product;

namespace DesignPatternDemos
{
    //public class Product
    //{
    //    public void GetProductDetails()
    //    {
    //        Console.WriteLine("Fetching the Product Details");
    //    }
    //    public class Payment
    //    {
    //        public void MakePayment()
    //        {
    //            Console.WriteLine("Payment Done Successfully");
    //        }
    //    }
    //    public class Invoice
    //    {
    //        public void Sendinvoice()
    //        {
    //            Console.WriteLine("Invoice Send Successfully");
    //        }
    //    }
    //    // The Facade class provides a simple interface to the complex logic of one
    //    // or several subsystems. The Facade delegates the client requests to the
    //    // appropriate objects within the subsystem. 
    //    public class Order
    //    {
    //        public void PlaceOrder()
    //        {
    //            Console.WriteLine("Place Order Started");
    //            //Get the Product Details
    //            Product product = new Product();
    //            product.GetProductDetails();
    //            //Make the Payment
    //            Payment payment = new Payment();
    //            payment.MakePayment();
    //            //Send the Invoice
    //            Invoice invoice = new Invoice();
    //            invoice.Sendinvoice();
    //            Console.WriteLine("Order Placed Successfully");
    //        }
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //The Client will use the Facade Interface instead of the Subsystems
    //        Order order = new Order();
    //        order.PlaceOrder();
    //        Console.Read();
    //    }
    //}



    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        //Any other Properties as per the Business Requirements
    }
    public class Validator
    {
        public bool ValidateCustomer(Customer customer)
        {
            //Need to Validate the Customer Object
            Console.WriteLine("Customer Validated...");
            Console.WriteLine($"Name:{customer.Name}");
            Console.WriteLine($"Email:{customer.Email}");
            Console.WriteLine($"Mobile:{customer.MobileNumber}");
            Console.WriteLine($"Address:{customer.Address}");
            return true;
        }
    }
    public class CustomerDataAccessLayer
    {
        public bool SaveCustomer(Customer customer)
        {
            //Save the Customer in the Database
            Console.WriteLine("\nCustomer Saved into the Database...");
            return true;
        }
    }
    public class Email
    {
        public bool SendRegistrationEmail(Customer customer)
        {
            //Send Registration Successful Email to Customer
            Console.WriteLine("\nRegistration Email Send to Customer...");
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Step1: Create an Instance of Customer Class
            Customer customer = new Customer()
            {
                Name = "Pranaya",
                Email = "info@dotnettutorials.net",
                MobileNumber = "1234567890",
                Address = "BBSR, Odisha, India"
            };
            //Step2: Validate the Customer
            Validator validator = new Validator();
            bool IsValid = validator.ValidateCustomer(customer);
            //Step3: Save the Customer Object into the database
            CustomerDataAccessLayer customerDataAccessLayer = new CustomerDataAccessLayer();
            bool IsSaved = customerDataAccessLayer.SaveCustomer(customer);
            //Step4: Send the Registration Email to the Customer
            Email email = new Email();
            email.SendRegistrationEmail(customer);
            Console.ReadKey();
        }
    }

    //public class CustomerRegistration
    //{
    //    public bool RegisterCustomer(Customer customer)
    //    {
    //        //Step1: Validate the Customer
    //        Validator validator = new Validator();
    //        bool IsValid = validator.ValidateCustomer(customer);
    //        //Step1: Save the Customer Object into the database
    //        CustomerDataAccessLayer customerDataAccessLayer = new CustomerDataAccessLayer();
    //        bool IsSaved = customerDataAccessLayer.SaveCustomer(customer);
    //        //Step3: Send the Registration Email to the Customer
    //        Email email = new Email();
    //        email.SendRegistrationEmail(customer);
    //        return true;
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        // Create an Instance of Customer Class
    //        Customer customer = new Customer()
    //        {
    //            Name = "Pranaya",
    //            Email = "info@dotnettutorials.net",
    //            MobileNumber = "1234567890",
    //            Address = "BBSR, Odisha, India"
    //        };
    //        //Using Facade Class
    //        CustomerRegistration customerRegistration = new CustomerRegistration();
    //        customerRegistration.RegisterCustomer(customer);
    //        Console.ReadKey();
    //    }
    //}
}
