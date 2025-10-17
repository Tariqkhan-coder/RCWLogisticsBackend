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

        public async Task<ResponseVm> LoginAdmin(LoginAdmin login)
        {
            ResponseVm response = new ResponseVm();

            try
            {
                var admin = await _db.Admins.FirstOrDefaultAsync(u => u.Username == login.Username);

                if (admin == null)
                {
                    response.ResponseCode = 401;
                    response.ErrorMessage = "Invalid username or password.";
                    return response;
                }

                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(login.Password, admin.PasswordHash);
                if (!isPasswordValid)
                {
                    response.ResponseCode = 401;
                    response.ErrorMessage = "Invalid username or password.";
                    return response;
                }

                var token = _jwtService.GenerateJwtToken(admin);

                response.ResponseCode = 200;
                response.ResponseMessage = "Login successful.";
                response.Data = new
                {
                    Token = token,
                    Username = admin.Username,
                    AdminId = admin.AdminId
                };

                return response;
            }
            catch (Exception ex)
            {
                response.ResponseCode = 500;
                response.ErrorMessage = $"Internal server error: {ex.Message}";
                return response;
            }
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


