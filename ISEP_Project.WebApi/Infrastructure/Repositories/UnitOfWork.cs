using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISEP_Project.WebApi.Infrastructure.Data;
using ISEP_Project.WebApi.Repositories;

namespace ISEP_Project.WebApi.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISEPDbContext _context;

        public UnitOfWork(ISEPDbContext context)
        {
            _context = context;
            Patients = new PatientRepository(context);
        }
        public IPatientRepository Patients { get; init; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}