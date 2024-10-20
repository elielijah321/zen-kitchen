using System;

namespace Project.Function
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
    }
}