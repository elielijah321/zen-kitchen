using Project.Function;

namespace AzureFunctions.Mappers
{
    public static class MenuMapper
    {
        public static Menu ToModel(this UpdateMenuRequestModel request){
            return new Menu
            {
                Id = request.Id,
                Name = request.Name,
                Recipes = request.Recipes,
            };

        }

        public static UpdateMenuResponseModel ToResponse(this Menu entity)
        {
            return new UpdateMenuResponseModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Recipes = entity.Recipes,
            };
        }
    }
}