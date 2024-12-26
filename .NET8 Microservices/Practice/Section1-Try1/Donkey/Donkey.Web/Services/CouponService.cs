using Donkey.Web.Models.DTO;
using Donkey.Web.Services.IService;
using Donkey.Web.Utility;
using static Donkey.Web.Utility.SD;

namespace Donkey.Web.Services
{
    public class CouponService : ICouponService
    {
        private IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.POST,
                Url = SD.CouponAPIBaseUri +"/api/coupons",
                Data = couponDto
            });
        }

        public Task<ResponseDto?> DeleteCouponAsync(int couponId)
        {
            return _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.DELETE,
                Url = SD.CouponAPIBaseUri + "/api/coupons/" + couponId
            });
        }

        public Task<ResponseDto?> GetAllCouponsAsync()
        {
            return _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = SD.CouponAPIBaseUri + "/api/coupons"
            });
        }

        public Task<ResponseDto?> GetCouponByCodeAsync(string couponCode)
        {
            return _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = SD.CouponAPIBaseUri + "/api/coupons/getbycode/" + couponCode
            });
        }

        public Task<ResponseDto?> GetCouponByIdAsync(int couponId)
        {
            return _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = SD.CouponAPIBaseUri + "/api/coupons/" + couponId
            });
        }

        public Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.PUT,
                Url = SD.CouponAPIBaseUri + "/api/coupons",
                Data = couponDto
            });
        }
    }
}
