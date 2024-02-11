using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class StoreContext: IdentityDbContext<AppUser>
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<MealBooking> MealsBooking { get; set; }
    }
}