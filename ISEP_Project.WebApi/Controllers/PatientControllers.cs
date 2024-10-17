using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISEP_Project.WebApi.Domain.Entities;
using ISEP_Project.WebApi.DTOs;
using ISEP_Project.WebApi.Infrastructure.Data;

namespace ISEP_Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ISEPDbContext _context;

        public PatientController(ISEPDbContext context)
        {
            _context = context;
        }

        // GET: api/patient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients()
        {
            var patients = await _context.Patients.ToListAsync();
            return Ok(patients.Select(p => new PatientDto
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                FullName = p.FullName,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                MedicalRecordNumber = p.MedicalRecordNumber,
                Email = p.Email,
                Phone = p.Phone,
                AllergiesOrMedicalConditions = p.AllergiesOrMedicalConditions,
                /*
                EmergencyContact = new EmergencyContactDto
                {
                    Name = p.EmergencyContact?.Name,
                    Phone = p.EmergencyContact?.Phone
                }
                */
            }));
        }

        // GET: api/patient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatient(string id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(new PatientDto
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                MedicalRecordNumber = patient.MedicalRecordNumber,
                Email = patient.Email,
                Phone = patient.Phone,
                AllergiesOrMedicalConditions = patient.AllergiesOrMedicalConditions,
                /*EmergencyContact = new EmergencyContactDto
                {
                    Name = patient.EmergencyContact?.Name,
                    Phone = patient.EmergencyContact?.Phone
                }
                */
            });
        }

        // POST: api/patient
        [HttpPost]
        public async Task<ActionResult<PatientDto>> PostPatient(PatientDto patientDto)
        {
            var patient = new Patient
            {
                FirstName = patientDto.FirstName,
                LastName = patientDto.LastName,
                FullName = patientDto.FullName,
                DateOfBirth = patientDto.DateOfBirth,
                Gender = patientDto.Gender,
                MedicalRecordNumber = patientDto.MedicalRecordNumber,
                Email = patientDto.Email,
                Phone = patientDto.Phone,
                AllergiesOrMedicalConditions = patientDto.AllergiesOrMedicalConditions,
                /*EmergencyContact = new EmergencyContact
                {
                    Name = patientDto.EmergencyContact.Name,
                    Phone = patientDto.EmergencyContact.Phone
                }
                */
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatient), new { id = patient.MedicalRecordNumber }, patientDto);
        }

        // PUT: api/patient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(string id, PatientDto patientDto)
        {
            if (id != patientDto.MedicalRecordNumber)
            {
                return BadRequest();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            patient.FirstName = patientDto.FirstName;
            patient.LastName = patientDto.LastName;
            patient.FullName = patientDto.FullName;
            patient.Gender = patientDto.Gender;
            patient.Email = patientDto.Email;
            patient.Phone = patientDto.Phone;
            patient.AllergiesOrMedicalConditions = patientDto.AllergiesOrMedicalConditions;
            /*patient.EmergencyContact = new EmergencyContact
            {
                Name = patientDto.EmergencyContact.Name,
                Phone = patientDto.EmergencyContact.Phone
            };
            */

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/patient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(string id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
