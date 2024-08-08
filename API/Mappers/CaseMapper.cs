using System;
using Project.Function;
// using AzureFunctions.Models;

namespace AzureFunctions.Mappers
{
    public static class CaseMapper
    {
        public static Case ToCase(this UpdateCaseRequestModel caseRequest){
            return new Case
            {
                Id = caseRequest.Id,
                Title = caseRequest.Title,
            };

        }

        public static UpdateCaseResponseModel ToStudentResponse(this Case caseEntity)
        {
            return new UpdateCaseResponseModel
            {
                Id = caseEntity.Id,
                Title = caseEntity.Title,
            };
        }
    }
}