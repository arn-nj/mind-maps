using AutoMapper;
using Donkey.Coupons.Api.Data;
using Donkey.Coupons.Api.Models;
using Donkey.Coupons.Api.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Donkey.Coupons.Api.Controllers
{
    [Route("api/coupons")]
    public class CouponsController : Controller
    {
        private AppDBContext _db;
        private IMapper _map;

        public CouponsController(AppDBContext db, IMapper map)
        {
            _db = db;
            _map = map;
        }

        [HttpGet]
        public ResponseDto GetAllAsync()
        {
            try
            {
                var coupons = _db.Coupons.ToList<Coupon>();
                var result = _map.Map<List<Coupon>, List<CouponDto>>(coupons);
                return new ResponseDto { Result = result, Success = true };

            }
            catch (Exception)
            {
                return new ResponseDto { Result = null, Success = false, Message = "Failed to get coupons" };
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseDto Get(int id)
        {
            try
            {
                var coupon = _db.Coupons.First(Coupons => Coupons.CouponId == id);
                var result = _map.Map<Coupon, CouponDto>(coupon);
                return new ResponseDto { Result = result, Success = true };

            }
            catch (Exception)
            {
                return new ResponseDto { Result = null, Success = false, Message = "Failed to get coupons" };
            }
        }

        [HttpPost]
        public ResponseDto Post([FromBody]CouponDto couponDto)
        {
            try
            {
                var coupon = _map.Map<CouponDto, Coupon>(couponDto);
                _db.Coupons.Add(coupon);
                _db.SaveChanges();
                return new ResponseDto { Result = _map.Map<Coupon, CouponDto>(coupon), Success = true, Message = "Coupon Created Successfully" };

            }
            catch (Exception)
            {

                return new ResponseDto { Result = null, Success = false, Message = "Failed to create coupon" };
            }
        }

        [HttpPut]
        public ResponseDto Put([FromBody]CouponDto couponDto)
        {
            try
            {
                var coupon = _map.Map<CouponDto, Coupon>(couponDto);

                if (!_db.Coupons.Any(Coupons => Coupons.CouponId == coupon.CouponId))
                {
                    return new ResponseDto { Result = null, Success = false, Message = "Coupon not found" };
                }

                _db.Coupons.Update(coupon);
                _db.SaveChanges();
                return new ResponseDto { Result = _map.Map<Coupon, CouponDto>(coupon), Success = true, Message = "Coupon Updated Successfully" };
            }
            catch (Exception)
            {
                return new ResponseDto { Result = null, Success = false, Message = "Failed to update coupon" };
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                var coupon = _db.Coupons.First(Coupons => Coupons.CouponId == id);
                if (coupon == null)
                {
                    return new ResponseDto { Result = null, Success = false, Message = "Coupon not found" };
                }
                _db.Coupons.Remove(coupon);
                _db.SaveChanges();
                return new ResponseDto { Result = null, Success = true, Message = "Coupon Deleted Successfully" };
            }
            catch (Exception)
            {
                return new ResponseDto { Result = null, Success = false, Message = "Failed to delete coupon" };

            }
        }

        [HttpGet]
        [Route("GetByCode/{couponCode}")]
        public ResponseDto GetByCode(string couponCode)
        {
            try
            {
                var coupon = _db.Coupons.First(Coupons => Coupons.CouponCode.ToLower() == couponCode.ToLower());
                var result = _map.Map<Coupon, CouponDto>(coupon);
                return new ResponseDto { Result = result, Success = true };
            }
            catch (Exception)
            {
                return new ResponseDto { Result = null, Success = false, Message = "Failed to get coupon" };
            }
        }
    }
}
