using System.Collections.Generic;

namespace Project.Function
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<MenuItem> Recipes { get; set; }
    }
}