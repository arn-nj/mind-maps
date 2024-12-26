using Donkey.Web.Models.DTO;
using Donkey.Web.Services.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Donkey.Web.Utility.SD;

namespace Donkey.Web.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory factory)
        {
           _httpClientFactory = factory;
        }
        public async Task<ResponseDto?> SendAsync(RequestDto request)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("DonkeyAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                //Token add
                if (!string.IsNullOrEmpty(request.AccessToken))
                {
                    message.Headers.Add("Authorization", $"Bearer {request.AccessToken}");
                }

                message.Method = request.ApiType switch
                {
                    ApiType.GET => HttpMethod.Get,
                    ApiType.POST => HttpMethod.Post,
                    ApiType.PUT => HttpMethod.Put,
                    ApiType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get
                };

                message.RequestUri = new Uri(request.Url);
                if (request.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(request.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage response = await client.SendAsync(message);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var successResponse = await response.Content.ReadAsStringAsync();
                        var responseDto = JsonConvert.DeserializeObject<ResponseDto>(successResponse);
                        return responseDto;
                    case HttpStatusCode.Unauthorized:
                        return new ResponseDto { Result = null, Success = false, Message = "Unauthorized" };
                    default:
                        return new ResponseDto { Result = null, Success = false, Message = "Error" };
                }



            }
            catch (Exception ex)
            {
                return new ResponseDto { Result = null, Success = false, Message = ex.Message };

            }
            


        }
    }
}
