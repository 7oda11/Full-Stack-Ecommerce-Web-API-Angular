using Ecom.Core.DTO;
using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastracture.Repositories
{
    public class AuthRepository:IAuth
    {
        private readonly UserManager<AppUser> userManager;

        public AuthRepository(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<string> RegisterAsync(RegisterDTO registerDTO)
        {
            if (registerDTO is null)
            {
                return null;
            }
            if(await userManager.FindByNameAsync(registerDTO.UserName) is not null)
            {
                return "this UserName is already registered";
            }
            if (await userManager.FindByEmailAsync(registerDTO.Email) is not null)
            {
                return "this Email is already registered";
            }
            AppUser user = new AppUser()
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email

            };
            var result=await userManager.CreateAsync(user,registerDTO.Password);
            if (result.Succeeded is not true)
            {
                return result.Errors.ToList()[0].Description;
            }
            //send active Email
            return "Done";
        }
    }
}
