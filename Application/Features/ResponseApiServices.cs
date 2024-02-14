using Domain.Models;

namespace Application.Features
{
    public static class ResponseApiServices
    {
        public static BaseResponseModel Response(int statusCode, object Data = null, string message = null)
        {
            bool success = false;

            if (statusCode >= 200 && statusCode < 300)
            {
                success = true;
            }

            var response = new BaseResponseModel
            {
                StatusCode = statusCode,
                Success = success,
                Data = Data,
                Message = message
            };

            return response;
        }
    }
}
