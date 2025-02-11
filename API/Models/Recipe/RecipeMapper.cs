using Project.Function;

namespace AzureFunctions.Mappers
{
    public static class RecipeMapper
    {
        public static Recipe ToModel(this UpdateRecipeRequestModel request){
            return new Recipe
            {
                Id = request.Id,
                Name = request.Name.Replace(",", "¸"),
                Ingredients = request.Ingredients,
                Price = request.Price
            };

        }

        public static UpdateRecipeResponseModel ToResponse(this Recipe entity)
        {
            return new UpdateRecipeResponseModel
            {
                Id = entity.Id,
                Name = entity.Name.Replace("¸", ","),
                Ingredients = entity.Ingredients,
                Price = entity.Price
            };
        }
    }
}