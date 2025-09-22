using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSWLogistics.Models
{
    public class Driver
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DriverId { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string FirstName { get; set; } = "";

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string LastName { get; set; } = "";

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string EmailAddress { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string PhoneNumber { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string StreetAddress { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string City { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string State { get; set; } = "";
         [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string ZipCode { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string Documents { get; set; } = "";

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string TruckType { get; set; } = "";

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string AdditionalEquipmentNotes { get; set; } = "";

    }
}
