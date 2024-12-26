using Donkey.Coupons.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Donkey.Coupons.Api.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { CouponId = 1, CouponCode = "10OFF", Discount = 10, MinimumAmount = 100 },
                new Coupon { CouponId = 2, CouponCode = "20OFF", Discount = 20, MinimumAmount = 200 },
                new Coupon { CouponId = 3, CouponCode = "30OFF", Discount = 30, MinimumAmount = 300 }
            );
        }

        public DbSet<Coupon> Coupons { get; set; }
    }
}
