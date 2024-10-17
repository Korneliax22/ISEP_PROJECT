using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISEP_Project.WebApi.DTOs
{
    public class PatientDto
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Key]
        [Required]
        [StringLength(50)]
        public string MedicalRecordNumber { get; set; } // Unique Identifier

        [Required]
        [EmailAddress]
        public string Email { get; set; } // Contact Information

        [Phone]
        public string Phone { get; set; } // Contact Information

        public List<string> AllergiesOrMedicalConditions { get; set; } = new List<string>(); // Optional

        //public EmergencyContactDto EmergencyContact { get; set; } // Emergency Contact
    }

    /*public class EmergencyContactDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    }
    */
}
