using Holcim.FileSend.Domain.Models;

namespace Holcim.FileSend.Application.Feature
{
    public class ResponseApiService
    {
        public static BaseResponseModel Response(int Statuscode, object Data = null, string message = null)
        {
            bool success = false;

            if (Statuscode >= 200 && Statuscode < 300)
                success = true;

            var result = new BaseResponseModel
            {

                StatusCode = Statuscode,
                Succes = success,
                Message = message,
                Data = Data
            };
            return result;

        }
    }
}
