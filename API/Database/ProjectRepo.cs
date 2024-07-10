using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project.Function;

namespace AzureFunctions.Database
{
    public class ProjectRepo
    {
        private readonly ProjectContext _ctx;

        public ProjectRepo(ProjectContext ctx)
        {
            _ctx = ctx;
        }

        public void AddCustomer(Customer newCustomer)
        {
            //Might need to parse the sortcode 
            newCustomer.StripeId = StripeService.CreateBACSSubscription(newCustomer);
            newCustomer.PaymentStatus = "Registered";
            
           _ctx.Customers.Add(newCustomer);
           SaveAll();
        }

        public void UpdateCustomer(Customer newCustomer)
        {
           var customerToUpdate = _ctx.Customers.FirstOrDefault(c => c.Id == newCustomer.Id);
           customerToUpdate.Name = newCustomer.Name;
           customerToUpdate.Email = newCustomer.Email;
           customerToUpdate.SortCode = newCustomer.SortCode;
           customerToUpdate.AccountNumber = newCustomer.AccountNumber;
           customerToUpdate.Address_Line1 = newCustomer.Address_Line1;
           customerToUpdate.Address_City = newCustomer.Address_City;
           customerToUpdate.Address_PostalCode = newCustomer.Address_PostalCode;
           customerToUpdate.LastPaymentDate = newCustomer.LastPaymentDate;

           customerToUpdate.StudentDiscount = newCustomer.StudentDiscount;
           customerToUpdate.PaymentStatus = newCustomer.PaymentStatus;

           SaveAll();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
           return _ctx.Customers;
        }

        public Customer GetCustomerById(string id)
        {
           return GetAllCustomers().FirstOrDefault(x => x.Id == id);
        }

        public Customer GetCustomerByEmail(string email)
        {
           return GetAllCustomers().FirstOrDefault(x => x.Email == email);
        }

        public void DeleteCustomer(string id)
        {
            Customer customer = GetCustomerById(id);
            StripeService.DeleteCustomer(customer.StripeId);
            _ctx.Customers.Remove(customer);
            SaveAll();
        }

        // Save
        private bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}