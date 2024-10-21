using System.ComponentModel.DataAnnotations;
namespace ProjectIsep.Model
{
    public class SurgeryRoom
    {
        [Key]
        public int SurgeryRoomId { get; set; }
        // Unique identifier for the room
        public int RoomNumber { get; set; }

        // Type of the room (e.g., operating room, consultation room, ICU)
        public string Type { get; set; }

        // Maximum number of patients or staff the room can accommodate
        public int Capacity { get; set; }

        // List of equipment assigned to the room
        public List<string> AssignedEquipment { get; set; }

        // Current status of the room (available, occupied, under maintenance)
        public string CurrentStatus { get; set; }

        // List of maintenance slots (times when the room is reserved for maintenance)
        public List<TimeSlot> MaintenanceSlots { get; set; }
    }
    public class TimeSlot
    {
        [Key]
        public DateTime Start { get; set; }  // Start time of the slot
        public DateTime End { get; set; }    // End time of the slot
    }
}
