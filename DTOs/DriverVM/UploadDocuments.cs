using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RCWLogistics.DTOs.DriverVM
{
    public class UploadDocuments
    {
        public long DriverId { get; set; }
       public string documents { get; set; } = "";
    }
}
