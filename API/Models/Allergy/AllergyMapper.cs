using Project.Function;

namespace AzureFunctions.Mappers
{
    public static class AllergyMapper
    {
        public static Allergy ToModel(this UpdateAllergyRequestModel request){
            return new Allergy
            {
                Id = request.Id,
                Name = request.Name,
            };

        }

        public static UpdateAllergyResponseModel ToResponse(this Allergy entity)
        {
            return new UpdateAllergyResponseModel
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
    }
}