using System;

namespace Project.Function
{
    public class Defendant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address_Line1 { get; set; }
        public string Address_City { get; set; }
        public string Address_PostalCode { get; set; }
    }
}