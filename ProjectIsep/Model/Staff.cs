namespace ProjectIsep.Model
{
    public class Staff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LicenseNumber { get; set; }
        public string Specialization { get; set; } // E.g., Cardiology, Orthopedics
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<AvailabilitySlot> AvailabilitySlots { get; set; }
    }

    public class AvailabilitySlot
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
