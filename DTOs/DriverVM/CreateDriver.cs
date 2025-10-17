using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSWLogistics.DTOs.DriverVM
{
    public class CreateDriver
    {
     
        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";
        
        public string EmailAddress { get; set; } = "";
        
        public string PhoneNumber { get; set; } = "";
        
        public string StreetAddress { get; set; } = "";
        
        public string City { get; set; } = "";
      
        public string State { get; set; } = "";
     
        public string ZipCode { get; set; } = "";
        public string AdditionalEquipmentNotes { get; set; } = "";
    
        public string TruckType { get; set; } = "";

    }
}
