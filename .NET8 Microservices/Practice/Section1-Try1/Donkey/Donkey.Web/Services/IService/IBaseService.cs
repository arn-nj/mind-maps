using Donkey.Web.Models.DTO;

namespace Donkey.Web.Services.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto request);
    }
}
