using Final.Bl.Services.Interfaces;
using Final.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Services.Concretes
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(AppUser appUser)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("FirstName", appUser.FirstName),
                new Claim(ClaimTypes.Name,appUser.UserName),
                new Claim(ClaimTypes.NameIdentifier,appUser.Id),
                new Claim(ClaimTypes.Role,"Admin")
            };
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(claims: claims,  signingCredentials: signingCredentials, issuer: _config["Jwt:Issuer"], audience: _config["Jwt:Audience"],expires:DateTime.Now.AddDays(1));
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
           
    }
    } }
