namespace ProjectIsep.Model
{
    public class Appointment
    {
        public int ID { get; set; }
        public int RequestID { get; set; }
        public int RoomID { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Status { get; set; }
    }
}
