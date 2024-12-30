using Donkey.Web.Models.DTO;
using Donkey.Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Donkey.Web.Controllers
{
    public class CouponsController : Controller
    {
        private ICouponService _couponService;

        public CouponsController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        public async Task<IActionResult> CouponsIndex()
        {
            var response = await _couponService.GetAllCouponsAsync();

            if (response != null && response.Success)
            {
                return View(JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result)));
            }
            else
            {
                TempData["error"] = response?.Message;
            }


            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CouponDto coupon)
        {
            if (ModelState.IsValid)
            {
                var response = await _couponService.CreateCouponAsync(coupon);
                if (response != null && response.Success)
                {
                    TempData["success"] = "Coupon Created Successfully";
                    return RedirectToAction(nameof(CouponsIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            else
            {
                TempData["error"] = "Invalid data";
            }
            return View(coupon);
        }

        
        public async Task<IActionResult> Delete(int couponId)
        {
            var coupon = await _couponService.GetCouponByIdAsync(couponId);

            if(coupon != null && coupon.Success)
            {
                return View(JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(coupon.Result)));
            }
            else
            {
                TempData["error"] = coupon?.Message;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] CouponDto couponDto)
        {
            var coupon = await _couponService.GetCouponByIdAsync(couponDto.CouponId);
            if (coupon == null || !coupon.Success)
            {
                TempData["error"] = "Coupon not found";
                return View(couponDto);
            }

            var response = await _couponService.DeleteCouponAsync(couponDto.CouponId);
            if (response != null && response.Success)
            {
                TempData["success"] = "Coupon Deleted Successfully";
                return RedirectToAction(nameof(CouponsIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            
            return View(couponDto);
        }

        public async Task<IActionResult> Edit(int couponId)
        {
            var coupon = await _couponService.GetCouponByIdAsync(couponId);

            if (coupon != null && coupon.Success)
            {
                return View(JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(coupon.Result)));
            }
            else
            {
                TempData["error"] = coupon?.Message;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                var coupon = await _couponService.GetCouponByIdAsync(couponDto.CouponId);
                if (coupon == null || !coupon.Success)
                {
                    TempData["error"] = "Coupon not found";
                    return View(couponDto);
                }
                var response = await _couponService.UpdateCouponAsync(couponDto);
                if (response != null && response.Success)
                {
                    TempData["success"] = "Coupon Updated Successfully";
                    return RedirectToAction(nameof(CouponsIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            else
            {
                TempData["error"] = "Invalid data";
            }
            return View(couponDto);
        }
    }
}
