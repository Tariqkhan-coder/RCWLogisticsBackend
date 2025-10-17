using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RCWLogistics.DTOs.DriverVM
{
    public class UploadDocuments
    {
        [FromForm(Name = "DriverId")]
        public long DriverId { get; set; }

        [FromForm(Name = "Images")]
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();
    }
}
