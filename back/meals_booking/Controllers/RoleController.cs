using API.DTO;
using API.ErrorsHandeling;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : ApiControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IdentityRole), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddRole (RoleDto model)
        {
            IdentityRole roleModel = new()
            {
                Name = model.Name
            };

            var result = await _roleManager.CreateAsync(roleModel);

            if (!result.Succeeded)
                return BadRequest(new ApiResponse(400));
                
            return Ok(model.Name);
        }
    }
}
