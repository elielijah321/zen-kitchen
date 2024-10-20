using System;

namespace Project.Function
{
    public class MenuItem : BaseEntity
    {
        public Guid MenuId { get; set; }
        public Guid RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}