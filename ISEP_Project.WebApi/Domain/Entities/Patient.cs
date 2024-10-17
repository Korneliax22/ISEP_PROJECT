using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISEP_Project.WebApi.Domain.Entities
{
    public class Patient
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        
        [StringLength(200)]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [StringLength(50)]
        public string MedicalRecordNumber { get; set; } // Unique Identifier

        [Required]
        [EmailAddress]
        public string Email { get; set; } // Contact Information

        [Phone]
        public string Phone { get; set; } // Contact Information

        public List<string> AllergiesOrMedicalConditions { get; set; } = new List<string>(); // Optional

        //public EmergencyContact EmergencyContact { get; set; } // Emergency Contact

        //public List<Appointment> AppointmentHistory { get; set; } = new List<Appointment>(); // Appointment History
    }

    /*public class EmergencyContact
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    }

    public class Appointment
    {
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }
        // Additional properties as needed
    }
    */
}
