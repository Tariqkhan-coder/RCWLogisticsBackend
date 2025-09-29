using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCWLogisticsBackend.DTOs.Admin;
using RCWLogisticsBackend.Interfaces;
using RSWLogistics.Interfaces;
using RSWLogistics.LogisticsDb;
using RSWLogistics.Services;

namespace RCWLogisticsBackend.Controllers.AdminController
{

    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;

        private readonly RSWDb _db;
        public AdminController(IAdmin admin, RSWDb db)
        {
            _admin = admin;
            _db = db;
        }
        [HttpPost("CreateAdmin")]
        public async Task<IActionResult> CreateAdmin(CreateAdminVm admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid admin data.");
            }
            var result = await _admin.CreateAdmin(admin);
            return Ok(result);
        }
        [HttpPost("LoginAdmin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> LoginAdmin(LoginAdmin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid admin data.");
            }
            var result = await _admin.LoginAdmin(admin);
            return Ok(result);
        }
        [HttpGet("GetAllDrivers")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllDrivers()
        {
            var result = await _admin.GetAllDrivers();
            return Ok(result);
        }
    }
}
