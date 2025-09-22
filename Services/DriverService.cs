using Microsoft.EntityFrameworkCore;
using RCWLogistics.DTOs.DriverVM;
using RCWLogistics.Models;
using RSWLogistics.CommonMethods;
using RSWLogistics.DTOs.DriverVM;
using RSWLogistics.Helpers;
using RSWLogistics.Interfaces;
using RSWLogistics.LogisticsDb;
using RSWLogistics.Models;
using RSWLogistics.ResponseVM;
using System.Runtime.InteropServices.Marshalling;

namespace RSWLogistics.Services
{
    public class DriverService : IDriver
    {
        private readonly IConfiguration _configuration;
        private readonly RSWDb _db;
        private readonly EmailService _emailService;
        private readonly JwtService _jwtService;
        public DriverService(RSWDb db, IConfiguration configuration, JwtService jwtService, EmailService emailService)
        {
            _configuration = configuration;
            _db = db;
            _jwtService = jwtService;
            _emailService = emailService;
            // _storedProcExecutor = storedProcExecutor;
        }
        public async Task<ResponseVm> CreateDriver(CreateDriver driver)
        {
            ResponseVm response = new ResponseVm();

            var existingUser = await _db.Drivers.FirstOrDefaultAsync(u => u.EmailAddress == driver.EmailAddress);
            if (existingUser != null)
            {
                response.ResponseCode = 409;
                response.ErrorMessage = "User already exists.";
                return response;
            }

            Driver newUser = new Driver
            {

                FirstName = driver.FirstName,
                LastName = driver.LastName,
                EmailAddress = driver.EmailAddress,

                PhoneNumber = driver.PhoneNumber,
                StreetAddress = driver.StreetAddress,
                City = driver.City,
                State = driver.State,
                ZipCode = driver.ZipCode,
            };
            string verificationLink = $"https://yourdomain.com/verify-email?userId={newUser.DriverId}";
            string subject = "Verify your RCWLogistics Driver account";
            string body = $"<h2>Welcome to RCWLogisticsLLC!</h2><p>Click below to verify your email:</p><a href='{verificationLink}'>Verify Email</a>";
            await _emailService.SendEmailAsync(newUser.EmailAddress, subject, body);

            await _db.Drivers.AddAsync(newUser);
            await _db.SaveChangesAsync();
            response.ResponseCode = 200;
            response.ResponseMessage = "User created. Please verify email.";
            response.Data = newUser;

            return response;
        }
        public async Task<ResponseVm> UpdateDriver(UpdateDriverVM driver)
        {
            ResponseVm response = new ResponseVm();
            var existingUser = await _db.Drivers.FirstOrDefaultAsync(u => u.DriverId == driver.DriverId);

            if (existingUser == null)
            {
                response.ResponseCode = 404;
                response.ErrorMessage = "User not found.";
                return response;
            }

            // Update only if provided
            if (!string.IsNullOrWhiteSpace(driver.FirstName))
                existingUser.FirstName = driver.FirstName;

            if (!string.IsNullOrWhiteSpace(driver.LastName))
                existingUser.LastName = driver.LastName;

            if (!string.IsNullOrWhiteSpace(driver.EmailAddress))
                existingUser.EmailAddress = driver.EmailAddress;

            if (!string.IsNullOrWhiteSpace(driver.PhoneNumber))
                existingUser.PhoneNumber = driver.PhoneNumber;

            if (!string.IsNullOrWhiteSpace(driver.StreetAddress))
                existingUser.StreetAddress = driver.StreetAddress;

            if (!string.IsNullOrWhiteSpace(driver.City))
                existingUser.City = driver.City;

            if (!string.IsNullOrWhiteSpace(driver.State))
                existingUser.State = driver.State;

            if (!string.IsNullOrWhiteSpace(driver.ZipCode))
                existingUser.ZipCode = driver.ZipCode;
            _db.Drivers.Update(existingUser);
            await _db.SaveChangesAsync();

            response.ResponseCode = 200;
            response.ResponseMessage = "User updated successfully.";
            response.Data = existingUser;
            return response;
        }
        public async Task<ResponseVm> DeleteDriver(long driverId)
        {
            ResponseVm response = new ResponseVm();

            var existingUser = await _db.Drivers.FirstOrDefaultAsync(u => u.DriverId == driverId);
            if (existingUser == null)
            {
                response.ResponseCode = 404;
                response.ErrorMessage = "User not found.";
                return response;
            }

            _db.Drivers.Remove(existingUser);
            await _db.SaveChangesAsync();

            response.ResponseCode = 200;
            response.ResponseMessage = "User deleted successfully.";
            response.Data = existingUser; // optional, agar delete kiya record return karna ho
            return response;
        }
        public async Task<ResponseVm> EquipmentsInformation(EquipmentInformationvm eq)
        {
            ResponseVm response = new ResponseVm();

            var existingDriver = await _db.Drivers.FirstOrDefaultAsync(d => d.DriverId == eq.DriverId);
            if (existingDriver == null)
            {
                response.ResponseCode = 404;
                response.ErrorMessage = "Driver not found.";
                return response;
            }

            // Update only provided fields (null/empty skip logic)
            if (!string.IsNullOrWhiteSpace(eq.TruckType))
                existingDriver.TruckType = eq.TruckType;
            if (!string.IsNullOrWhiteSpace(eq.AdditionalEquipmentNotes))
                existingDriver.AdditionalEquipmentNotes = eq.AdditionalEquipmentNotes;

            _db.Drivers.Update(existingDriver);
            await _db.SaveChangesAsync();

            response.ResponseCode = 200;
            response.ResponseMessage = "Driver Equipments add successfully.";
            response.Data = existingDriver;

            return response;
        }
        public async Task<ResponseVm> GetAllDrivers()
        {
            ResponseVm response = new ResponseVm();
            var drivers = Methods.ExecuteStoredProcedure( "GetAllDrivers");
            response.ResponseCode = 200;
            response.ResponseMessage = "Drivers retrieved successfully.";
            response.Data = drivers;
            return response;
        }
        public async Task<ResponseVm> UploadDriverDocuments(UploadDocuments documents)
        {
            ResponseVm response = new ResponseVm();

            var existingDriver = await _db.Drivers.FirstOrDefaultAsync(d => d.DriverId == documents.DriverId);
            if (existingDriver == null)
            {
                response.ResponseCode = 404;
                response.ErrorMessage = "Driver not found.";
                return response;
            }

            // Update only provided fields (null/empty skip logic)
            if (!string.IsNullOrWhiteSpace(documents.documents))
                existingDriver.Documents = documents.documents;

      

            _db.Drivers.Update(existingDriver);
            await _db.SaveChangesAsync();

            response.ResponseCode = 200;
            response.ResponseMessage = "Driver documents uploaded/updated successfully.";
            response.Data = existingDriver;

            return response;
        }
        public async Task<ResponseVm> RequestLoad(RequestLoadVM request)
        {
            ResponseVm response = new ResponseVm();
            Loads newload = new Loads
            {
                EmailAddress = request.EmailAddress,
                ContactNumber = request.ContactNumber,
                PickUpLocation = request.PickUpLocation,
                DropOffLocation = request.DropOffLocation,
                PickUpDate = request.PickUpDate,
                DeliveryDate = request.DeliveryDate,
                EquipmentType = request.EquipmentType,
                Weight = request.Weight,
                Dimensions = request.Dimensions,
                Description = request.Description,
                TargetRate = request.TargetRate,
                AdditionalNotes = request.AdditionalNotes

            };
            string verificationLink = $"https://yourdomain.com/verify-email?userId={newload.LoadId}";
            string subject = "Verify your RCWLogistics Driver account";
            string body = $"<h2>Welcome to RCWLogisticsLLC!</h2><p>Click below to verify your email:</p><a href='{verificationLink}'>Verify Email</a>";
            await _emailService.SendEmailAsync(newload.EmailAddress, subject, body);

            await _db.Loads.AddAsync(newload);
            await _db.SaveChangesAsync();
            response.ResponseCode = 200;
            response.ResponseMessage = "User created. Please verify email.";
            response.Data = newload;

            return response;
        }
    }
}
