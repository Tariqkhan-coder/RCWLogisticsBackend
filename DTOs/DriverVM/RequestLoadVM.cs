using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCWLogistics.DTOs.DriverVM
{
    public class RequestLoadVM
    {
        public string EmailAddress { get; set; } = "";
        public string ContactNumber { get; set; }
        public string PickUpLocation { get; set; } = "";

        public string DropOffLocation { get; set; } = "";

      
        public string PickUpDate { get; set; } = "";
        
        public string DeliveryDate { get; set; } = "";
        
        public string EquipmentType { get; set; } = "";
       
        public string Weight { get; set; } = "";
       
        public string Dimensions { get; set; } = "";
        
        public string Description { get; set; } = "";
        
        public string Documents { get; set; } = "";

        
        public string TargetRate { get; set; } = "";

       
        public string AdditionalNotes { get; set; } = "";
    }
}
