using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ProjectIsep.Data;
using ProjectIsep.Model;


namespace TestprojectARQSI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ChirurgicDbContext _context;

        public AdminController(ChirurgicDbContext context)
        {
            _context = context;
        }

        [HttpPost("create-patient")]
        public async Task<IActionResult> CreatePatient([FromBody] Patient patient)
        {
            if (!ModelState.IsValid || patient == null)
            {
                return BadRequest(new { message = "invalid patient data." });
            }

            // Check if the email or phone is already used
            var existingPatient = await _context.Patients
                .FirstOrDefaultAsync(p => p.Email == patient.Email || p.Phone == patient.Phone);

            if (existingPatient != null)
            {
                return BadRequest(new { message = "Email or phone number already in use." });
            }

            // Generate unique Medical Record Number (this will be the auto-generated Id)
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Patient profile created successfully.", patientId = patient.Id });
        }

        [HttpPost("register-backoffice-user")]
        public async Task<IActionResult> RegisterBackofficeUser([FromBody] User newUser)
        {
            // Validate email and role
            if (string.IsNullOrEmpty(newUser.Email) || string.IsNullOrEmpty(newUser.Role))
                return BadRequest(new { message = "Invalid user data." });

            // Check if user with the same email already exists
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);
            if (existingUser != null)
                return BadRequest(new { message = "User with this email already exists." });

            // Set up the user
            newUser.IsActive = false; // Not active until they set up their password
            newUser.CreatedAt = DateTime.UtcNow;

            // Add user to the database
            _context.Users.Add(newUser); //te
            await _context.SaveChangesAsync();

            // Simulate sending a one-time setup link (extend with actual email service)
            await SendSetupLink(newUser.Email);

            return Ok(new { message = "User registered, one-time setup link sent." });
        }

        private Task SendSetupLink(string email)
        {
            Console.WriteLine($"Setup link sent to {email}.");
            return Task.CompletedTask;
        }
    }
}
