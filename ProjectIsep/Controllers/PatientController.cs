using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectIsep.Data;
using ProjectIsep.Model;

namespace TestprojectARQSI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ChirurgicDbContext _context;

        public PatientController(ChirurgicDbContext context) {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterPatient([FromBody] Patient patient)
        {

            if (patient == null)
            {
                return BadRequest(new { message = "Invalid patient data." });
            }

            var existingPatient = await _context.Patients
           .FirstOrDefaultAsync(p => p.Email == patient.Email);

            // Save the new patient to the database
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            // Mock: Send verification email (extend this to integrate with actual email service)
            await SendVerificationEmail(patient.Email);

            return Ok(new { message = "Registration successful. Please check your email to verify your account." });
        }
            private Task SendVerificationEmail(string email)
            {
                // Simulate sending a verification email
                Console.WriteLine($"Verification email sent to {email}.");
                return Task.CompletedTask;
            }

            // Mock method to handle email verification
            [HttpGet("verify-email")]
            public async Task<IActionResult> VerifyEmail(string email)
            {
                var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Email == email);

                if (patient == null)
                {
                    return BadRequest(new { message = "Invalid verification link." });
                }

                patient.EmailVerified = true;
                await _context.SaveChangesAsync();

                return Ok(new { message = "Email successfully verified." });
            }
        }
    }
