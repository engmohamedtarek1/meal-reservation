using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager);
    }
}
