using Microsoft.OpenApi.Models;

namespace ProjectIsep.Model
{
    public class OperationRequest
    {
        public int ID { get; set; }  

        public int PatientID { get; set; }  
        public Patient Patient { get; set; }

        public int DoctorID { get; set; }  
        public Staff Doctor { get; set; }  

        public int OperationTypeID { get; set; }  
        public OperationType OperationType { get; set; }  

        public DateTime DeadlineDate { get; set; }  

        public string Priority { get; set; }  
    }
}
