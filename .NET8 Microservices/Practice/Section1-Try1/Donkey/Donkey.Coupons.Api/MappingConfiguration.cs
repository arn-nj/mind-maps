using AutoMapper;

namespace Donkey.Coupons.Api
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Models.Coupon, Models.DTO.CouponDto>();
                cfg.CreateMap<Models.DTO.CouponDto, Models.Coupon>();
                cfg.CreateMap<Models.DTO.ResponseDto, Models.DTO.ResponseDto>();
            });
        }
    }
}
