using System;

namespace Project.Function
{
    public class Customer
    {
        public string Id { get; set; }
        public string StripeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SortCode { get; set; }
        public string AccountNumber { get; set; }
        public string Address_Line1 { get; set; }
        public string Address_City { get; set; }
        public string Address_PostalCode { get; set; }
        public string PaymentStatus { get; set; }
        public bool StudentDiscount { get; set; }
        public DateTime? LastPaymentDate { get; set; }
    }
}