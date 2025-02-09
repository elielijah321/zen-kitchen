using System.Collections.Generic;

namespace Project.Function
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<RecipeItem> Ingredients { get; set; }
        public long Price { get; set; }
    }
}