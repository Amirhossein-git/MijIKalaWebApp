using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MijiKalaWebApp.Models.ViewModels;

namespace MijiKalaWebApp.API.Controllers
{
    [ApiController]
    public class TokenController : Controller
    {
        private UserManager<IdentityUser> _userManager;

        public TokenController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> GetToken(SignInViewModel signInViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("رمز عبور یا نام کاربری اشتباه است");
            }
            var user = await _userManager.FindByNameAsync(signInViewModel.UserName);
            if (user == null)
            {
                return BadRequest("رمز عبور یا نام کاربری اشتباه است");
            }
            var checkPassword = await _userManager.CheckPasswordAsync(user, signInViewModel.PassWord);
            if (!checkPassword)
            {
                return BadRequest("رمز عبور یا نام کاربری اشتباه است");
            }

            var claims = await _userManager.GetClaimsAsync(user);
            var roles = String.Join(',', await _userManager.GetRolesAsync(user));

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim("Username", user.UserName));
            claims.Add(new Claim("Roles", roles));

            var key = new SymmetricSecurityKey(Encoding.Unicode.GetBytes("M I J I -app   PA3c3wOrDd.."));
            var token = new JwtSecurityToken(
                issuer: "http://localhost",
                audience: "http://localhost",
                claims: claims,
                expires: DateTime.Now.AddHours(6),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
            return Json(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expires = token.ValidTo,
            });
        }
    }
}