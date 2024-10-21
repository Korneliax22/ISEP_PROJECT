namespace ProjectIsep.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool EmailVerified { get; set; }
        public string MedicalRecordNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Allergies { get; set; }
        public string EmergencyContact { get; set; }
        public List<Appointment> AppointmentHistory { get; set; }
    }
}
