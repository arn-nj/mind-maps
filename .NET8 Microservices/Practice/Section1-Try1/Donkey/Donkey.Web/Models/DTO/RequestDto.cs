using static Donkey.Web.Utility.SD;

namespace Donkey.Web.Models.DTO
{
    public class RequestDto
    {
        public string Url { get; set; }
        public ApiType ApiType { get; set; } = ApiType.GET;
        public object? Data { get; set; }
        public string AccessToken { get; set; }
    }
}
