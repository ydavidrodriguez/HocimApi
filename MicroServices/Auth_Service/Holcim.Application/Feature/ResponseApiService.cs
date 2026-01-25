using Holcim.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Application.Feature
{
    public class ResponseApiService
    {
        public static object Response(int Statuscode, object? Data = null, string? message = null)
        {
            bool success = false;

            if (Statuscode >= 200 && Statuscode < 300)
                success = true;

            var result = new BaseResponseModel
            {

                StatusCode = Statuscode,
                Succes = success,
                Message = message ?? string.Empty,
                Data = Data
            };
            return result;
        }

    }
}
