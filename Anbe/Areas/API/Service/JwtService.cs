using Anbe.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Anbe.Areas.API.Service
{
    public class JwtService : IJwtService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public JwtService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GenerateTokenAsync(ApplicationUser User)
        {
            var secretKey = Encoding.UTF8.GetBytes("1234567890asdABCDEFGHIJ");
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = "http://www.anbe.shop",
                Audience = "http://www.anbe.shop",
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(120),
                SigningCredentials = signingCredentials,
                Subject = new ClaimsIdentity(await GetClaimsAsync(User)),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }


        public async Task<IEnumerable<Claim>> GetClaimsAsync(ApplicationUser User)
        {
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,User.UserName),
                new Claim(ClaimTypes.NameIdentifier,User.Id),
                new Claim(ClaimTypes.MobilePhone,User.PhoneNumber),
                new Claim("SecurityStampClaimTypes",User.SecurityStamp),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var Roles = await _userManager.GetRolesAsync(User);
            foreach (var item in Roles)
                Claims.Add(new Claim(ClaimTypes.Role, item));

            return Claims;
        }
    }
}
