using System;
using Project.Function;
// using AzureFunctions.Models;

namespace AzureFunctions.Mappers
{
    public static class DefendantMapper
    {
        public static Defendant ToStudent(this UpdateDefendantRequestModel defendantRequest){
            return new Defendant
            {
                Id = defendantRequest.Id,
                Name = defendantRequest.Name,
            };

        }

        public static UpdateDefendantResponseModel ToStudentResponse(this Defendant defendantEntity)
        {
            return new UpdateDefendantResponseModel
            {
                Id = defendantEntity.Id,
                Name = defendantEntity.Name,
            };
        }
    }
}