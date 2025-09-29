using Microsoft.EntityFrameworkCore;
using RCWLogisticsBackend.DTOs.Admin;
using RCWLogisticsBackend.Interfaces;
using RCWLogisticsBackend.Models;
using RSWLogistics.CommonMethods;
using RSWLogistics.Helpers;
using RSWLogistics.LogisticsDb;
using RSWLogistics.Models;
using RSWLogistics.ResponseVM;

namespace RCWLogisticsBackend.Services
{
    public class AdminService : IAdmin
    {
        private readonly IConfiguration _configuration;
        private readonly RSWDb _db;
        private readonly EmailService _emailService;
        private readonly JwtService _jwtService;
        public AdminService(RSWDb db, IConfiguration configuration, JwtService jwtService, EmailService emailService)
        {
            _configuration = configuration;
            _db = db;
            _jwtService = jwtService;
            _emailService = emailService;
            // _storedProcExecutor = storedProcExecutor;
        }
        public async Task<ResponseVm> CreateAdmin(CreateAdminVm admin)
        {
            ResponseVm response = new ResponseVm();

            var existingUser = await _db.Admins.FirstOrDefaultAsync(u => u.Username == admin.Username);
            if (existingUser != null)
            {
                response.ResponseCode = 409;
                response.ErrorMessage = "User already exists.";
                return response;
            }

            Admins newUser = new Admins
            {
                Username = admin.Username,
                PasswordHash = admin.Password,
            };
            await _db.Admins.AddAsync(newUser);
            await _db.SaveChangesAsync();
            response.ResponseCode = 200;
            response.ResponseMessage = "Admin Created.";
            response.Data = newUser;

            return response;
        }
        public async Task<ResponseVm> LoginAdmin(LoginAdmin login)
        {
            ResponseVm response = new ResponseVm();

            var admin = await _db.Admins.FirstOrDefaultAsync(u => u.Username == login.Username);

            if (admin == null || admin.PasswordHash != login.Password)
            {
                response.ResponseCode = 401;
                response.ErrorMessage = "Invalid username or password.";
                return response;
            }

            // Generate JWT token
            var token = _jwtService.GenerateJwtToken(admin);

            response.ResponseCode = 200;
            response.ResponseMessage = "Login successful.";
            response.Data = new { Token = token };

            return response;
        }
        public async Task<ResponseVm> GetAllDrivers()
        {
            ResponseVm response = new ResponseVm();
            var drivers = Methods.ExecuteStoredProcedure("GetAllDrivers");
            response.ResponseCode = 200;
            response.ResponseMessage = "Drivers retrieved successfully.";
            response.Data = drivers;
            return response;
        }
    }
}


