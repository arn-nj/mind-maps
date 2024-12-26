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
            _couponService  = couponService;
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
    }
}
