using DardelinMarket.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;

namespace DardelinMarket.Infrastructure
{
    public class Signing
    {
        public static async Task SignInAsync(LoginModel model, HttpContext context)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, model.Name),

                new Claim(ClaimTypes.Email, model.Email),

                new Claim(ClaimTypes.Role, model.Role)
            };

            ClaimsIdentity identity = 
                new ClaimsIdentity(claims, "ApplicationCookie", ClaimTypes.Name, ClaimTypes.Role);


            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }

        public static async Task SignOutAsync(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
