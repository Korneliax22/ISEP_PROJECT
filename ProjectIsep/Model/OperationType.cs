namespace ProjectIsep.Model
{
    public class OperationType
    {
        public int ID { get; set; }  

        public string Name { get; set; }  

        public List<string> RequiredStaffBySpecialization { get; set; }  

        public TimeSpan EstimatedDuration { get; set; }
    }
}
