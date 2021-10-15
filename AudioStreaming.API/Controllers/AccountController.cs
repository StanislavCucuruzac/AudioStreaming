using AudioStreaming.API.Infrastructure.Configurations;
using AudioStreaming.Common.Dtos.Account;
using AudioStreaming.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AudioStreaming.API.Controllers
{
    [Route("api/account")]
    public class AccountController : AppBaseController
    {
        private readonly AuthOptions _authenticationOptions;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _manager;

        public AccountController(IOptions<AuthOptions> authenticationOptions, SignInManager<User> signInManager, UserManager<User> manager)
        {
            _authenticationOptions = authenticationOptions.Value;
            _signInManager = signInManager;
            _manager = manager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var checkingPasswordResult = await _signInManager.PasswordSignInAsync(userForLoginDto.Username, userForLoginDto.Password, false, false);

            if (checkingPasswordResult.Succeeded)
            {
                var user = await _manager.FindByNameAsync(userForLoginDto.Username);
                var userRoles = await _manager.GetRolesAsync(user);
                var authClaims = new List<Claim>
               {
                   new Claim(ClaimTypes.NameIdentifier, user.UserName),

};
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
            
                var signinCredentials = new SigningCredentials(_authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
                var jwtSecurityToken = new JwtSecurityToken(
                   
                     issuer: _authenticationOptions.Issuer,
                     audience: _authenticationOptions.Audience,
                     claims: authClaims,
                     expires: DateTime.Now.AddDays(30),
                     signingCredentials: signinCredentials
                );

                var tokenHandler = new JwtSecurityTokenHandler();

                var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);

                return Ok(new { AccessToken = encodedToken });
            }

            return Unauthorized();
        }
    }
}
