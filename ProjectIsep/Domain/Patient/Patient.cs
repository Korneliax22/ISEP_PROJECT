namespace ProjectIsep;

public class Patient
{
public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; } // firstname + middle names + lastname
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string MedicalRecordNumber { get; private set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<string> Allergies { get; set; } // Optional
        public string EmergencyContact { get; set; }
        // public List<Appointment> AppointmentHistory { get; set; } // Assuming there's an Appointment class

        public Patient(string firstName, string lastName, DateTime dateOfBirth, char gender, string email, string phone, 
                       string emergencyContact)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            MedicalRecordNumber = Guid.NewGuid().ToString();
            Email = email;
            Phone = phone;
            Allergies = new List<string>();
            EmergencyContact = emergencyContact;
            //AppointmentHistory = new List<Appointment>(); // Initialize as empty list
        }

        // to add an allergy to the list of allergy's of the patient
        public void AddAllergy(string allergy)
        {
            if (!Allergies.Contains(allergy))
            {
                Allergies.Add(allergy);
            }
        }

        // returns the patients age
        public int GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth > today.AddYears(-age)) age--;
            return age;
        }
}
