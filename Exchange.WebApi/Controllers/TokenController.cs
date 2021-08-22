using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Exchange.Domain.Common.Command;
using Exchange.Domain.DataInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Exchange.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        
        private IConfiguration _configuration;
        //private IOwnerReadService _ownerReadService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public TokenController(IConfiguration config)
        {
            _configuration = config;
            //_ownerReadService = readService;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenCommand"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetToken(CreateTokenCommand tokenCommand)
        {
            if (tokenCommand != null && tokenCommand.UserName != null && tokenCommand.Password != null)
            {
                bool passCheck = tokenCommand.UserName.Equals("admin", StringComparison.InvariantCultureIgnoreCase)
                                 && tokenCommand.Password.Equals("admin", StringComparison.InvariantCultureIgnoreCase);

                if (passCheck)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}