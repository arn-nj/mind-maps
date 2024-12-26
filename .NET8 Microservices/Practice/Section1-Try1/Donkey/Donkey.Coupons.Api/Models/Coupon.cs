using System.ComponentModel.DataAnnotations;

namespace Donkey.Coupons.Api.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }

        [Required]
        public string CouponCode { get; set; }
        [Required]
        public int Discount { get; set; }
        public int MinimumAmount { get; set; }
    }
}
