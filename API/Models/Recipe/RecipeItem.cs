using System;
using System.Collections;

namespace Project.Function
{
    public class RecipeItem : BaseEntity
    {
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}