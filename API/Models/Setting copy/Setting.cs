using System.Collections.Generic;

namespace Project.Function
{
    public class Order : BaseEntity
    {
        public IEnumerable<Recipe> OrderDetails { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}