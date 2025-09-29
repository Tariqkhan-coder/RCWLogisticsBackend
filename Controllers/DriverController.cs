using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCWLogistics.DTOs.DriverVM;
using RSWLogistics.DTOs.DriverVM;
using RSWLogistics.Interfaces;
using RSWLogistics.LogisticsDb;
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
        [HttpPost("EquipmentsInformation")]
        [AllowAnonymous]
        public async Task<IActionResult> EquipmentsInformation(EquipmentInformationvm eq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var result = await _driverService.EquipmentsInformation(eq);
            return Ok(result);
        }
       
        [HttpPost("UploadDocuments")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadDriverDocuments(UploadDocuments documents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var result = await _driverService.UploadDriverDocuments(documents);
            return Ok(result);
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
