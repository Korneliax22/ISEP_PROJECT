using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISEP_Project.WebApi.Repositories;

namespace ISEP_Project.WebApi.Repositories
{
    public interface IUnitOfWork
    {
        IPatientRepository Patients { get; }
        void Save();
    }
}