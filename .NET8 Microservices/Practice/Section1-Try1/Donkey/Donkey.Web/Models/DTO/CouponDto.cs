﻿namespace Donkey.Web.Models.DTO
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public int Discount { get; set; }
        public int MinimumAmount { get; set; }
    }
}
