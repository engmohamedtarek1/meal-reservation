using API.DTO;
using API.ErrorsHandeling;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    public class MealController : ApiControllerBase
    {
        private readonly StoreContext _storeContext;
        private readonly UserManager<AppUser> _userManager;

        public MealController(StoreContext storeContext, UserManager<AppUser> userManager)
        {
            _storeContext = storeContext;
            _userManager = userManager;
        }

        [HttpPost]
        [ProducesResponseType(typeof(MealBooking), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MealBooking>> BookingMeal()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.FindByEmailAsync(userEmail);

            var today = DateTime.Now.Date;

            bool hasBooking = _storeContext.MealsBooking
                .Any(MB => MB.BookingDate.Date == today && (MB.StudentEmail == userEmail || MB.StudentSSN == user.SSN));

            if(hasBooking is true)
                return BadRequest(new ApiResponse(400));

            var mealBooking = new MealBooking()
            {
                StudentName = user.Name,
                StudentSSN = user.SSN,
                StudentEmail = userEmail
            };

            await _storeContext.AddAsync(mealBooking);

            var result = await _storeContext.SaveChangesAsync();

            if (result <= 0)
                return BadRequest(new ApiResponse(400));

            return Ok(mealBooking);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IReadOnlyList<MealBooking>>> GetAllMeals()
        {
            var meals = await _storeContext.MealsBooking.ToListAsync();

            return Ok(meals);
        }
    }
}