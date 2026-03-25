using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EF_core.Service;
using EF_core.Helper;
using EF_core.Model;
using System.IdentityModel.Tokens.Jwt;

namespace EF_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenHelper _tokenHelper;
        private readonly IEmployeeService _service;

        public AuthController(IEmployeeService service, TokenHelper tokenhelper)
        {
            _tokenHelper = tokenhelper;
            _service = service;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var employee = _service.ValidateUser(model.Email, model.Password);
            if(employee == null)
            {
                return Unauthorized("Invalid Credentials");
            }
            var token = _tokenHelper.GenerateAccessToken(model.Email);
            return Ok(new { AcessToken = new JwtSecurityTokenHandler().WriteToken(token) });
        }

    }
}
