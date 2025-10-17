using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RCWLogistics.DTOs.DriverVM;
using RSWLogistics.DTOs.DriverVM;
using RSWLogistics.Interfaces;
using RSWLogistics.LogisticsDb;
using RSWLogistics.ResponseVM;
using System.Collections.Generic;

namespace RSWLogistics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IDriver _driverService;

        private readonly RSWDb _db;

        public DriverController(IDriver driverService, RSWDb db)
        {
            _driverService = driverService;
            _db = db;
        }
        [HttpPost("CreateDriver")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateDriver(CreateDriver user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid user data.");
            }

            var result = await _driverService.CreateDriver(user);

            return Ok(result);
        }
        [HttpPost("UpdateDriver")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateDriver(UpdateDriverVM user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid user data.");
            }
            var result = await _driverService.UpdateDriver(user);
            return Ok(result);
        }
        [HttpDelete("DeleteDriver/{driverId}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteDriver(long driverId)
        {
            var result = await _driverService.DeleteDriver(driverId);
            return Ok(result);
        }


        [HttpPost("UploadDocuments")]
        [AllowAnonymous]
        public async Task<ResponseVm> UploadDriverDocuments([FromForm] UploadDocuments model)
        {
            ResponseVm response = new ResponseVm();

            var existingDriver = await _db.Drivers.FirstOrDefaultAsync(d => d.DriverId == model.DriverId);
            if (existingDriver == null)
            {
                response.ResponseCode = 404;
                response.ErrorMessage = "Driver not found.";
                return response;
            }

            if (model.Images == null || !model.Images.Any())
            {
                response.ResponseCode = 400;
                response.ErrorMessage = "No images uploaded.";
                return response;
            }

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DriverDocuments");
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            var filePaths = new List<string>();

            foreach (var file in model.Images)
            {
                var ext = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtensions.Contains(ext)) continue;

                var fileName = $"{Guid.NewGuid()}{ext}";
                var filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                filePaths.Add($"/DriverDocuments/{fileName}");
            }

            existingDriver.Documents = string.Join(",", filePaths);

            _db.Drivers.Update(existingDriver);
            await _db.SaveChangesAsync();

            response.ResponseCode = 200;
            response.ResponseMessage = "Driver images uploaded successfully.";
            response.Data = new
            {
                existingDriver.DriverId,
                ImageUrls = filePaths
            };

            return response;
        }

        [HttpPost("RequestLoad")]
        [AllowAnonymous]
        public async Task<IActionResult> RequestLoad(RequestLoadVM request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var result = await _driverService.RequestLoad(request);
            return Ok(result);
        }
    }
}
