using Project.Function;

namespace AzureFunctions.Mappers
{
    public static class IngredientMapper
    {
        public static Ingredient ToModel(this UpdateIngredientRequestModel request){
            return new Ingredient
            {
                Id = request.Id,
                Name = request.Name,
                Calories = request.Calories,
                Protein = request.Protein
            };

        }

        public static UpdateIngredientResponseModel ToResponse(this Ingredient entity)
        {
            return new UpdateIngredientResponseModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Calories = entity.Calories,
                Protein = entity.Protein
            };
        }
    }
}