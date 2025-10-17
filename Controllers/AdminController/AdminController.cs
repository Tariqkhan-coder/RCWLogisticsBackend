using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCWLogisticsBackend.DTOs.Admin;
using RCWLogisticsBackend.Interfaces;
using RSWLogistics.LogisticsDb;

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

   

    [AllowAnonymous]
    [HttpPost("LoginAdmin")]
    // Public endpoint to generate JWT
    public async Task<IActionResult> LoginAdmin(LoginAdmin admin)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid admin data.");

        var result = await _admin.LoginAdmin(admin);
        return Ok(result);
    }

    // Requires JWT token
    [AllowAnonymous]
    [HttpGet("GetAllDrivers")]
 
    public async Task<IActionResult> GetAllDrivers()
    {
        var result = await _admin.GetAllDrivers();
        return Ok(result);
    }
}
