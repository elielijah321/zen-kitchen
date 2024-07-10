using System;
using Project.Function;
// using AzureFunctions.Models;

namespace AzureFunctions.Mappers
{
    public static class CustomerMapper
    {
        public static Customer ToStudent(this UpdateCustomerRequestModel customerRequest){
            return new Customer
            {
                Id = customerRequest.Id,
                Name = customerRequest.Name,
            };

        }

        public static UpdateCustomerResponseModel ToStudentResponse(this Customer customerEntity)
        {
            return new UpdateCustomerResponseModel
            {
                Id = customerEntity.Id,
                Name = customerEntity.Name,
            };
        }
    }
}