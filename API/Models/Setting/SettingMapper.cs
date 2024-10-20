using System;
using Project.Function;

namespace AzureFunctions.Mappers
{
    public static class SettingMapper
    {
        public static Setting ToModel(this UpdateSettingRequestModel request){
            return new Setting
            {
                Id = request.Id,
                Name = request.Name,
                Value = request.Value,
            };

        }

        public static UpdateSettingResponseModel ToResponse(this Setting entity)
        {
            return new UpdateSettingResponseModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Value = entity.Value,
            };
        }
    }
}