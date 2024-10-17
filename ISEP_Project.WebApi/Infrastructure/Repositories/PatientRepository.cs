using Microsoft.EntityFrameworkCore;
using ISEP_Project.WebApi.Infrastructure.Data;
using ISEP_Project.WebApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ISEP_Project.WebApi.DTOs;

namespace ISEP_Project.WebApi.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ISEPDbContext _context;

        public PatientRepository(ISEPDbContext context)
        {
            _context = context;
        }
        public void Add(Patient p)
        {
            _context.Patients.Add(p);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            Patient p = GetById(id);
            if (p != null)
            {
                _context.Patients.Remove(p);
                int changed = _context.SaveChanges();
                return (changed > 0);
            }
            return false;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patient GetById(int id)
        {
            return _context.Patients.Find(id);
        }

        public void Update(Patient p)
        {
            _context.Patients.Update(p);
            _context.SaveChanges();
        }

        public IEnumerable<Patient> Search(SearchOptionsPatient options)
        {
            var query = _context.Patients.AsQueryable();

            if (!string.IsNullOrEmpty(options.Name))
            {
                query = query.Where(x => x.FullName.Contains(options.Name));
            }
            return query.ToList();
        }
    }
}
