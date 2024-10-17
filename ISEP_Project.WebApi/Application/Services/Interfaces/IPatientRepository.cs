using System.Collections.Generic;
using System.Threading.Tasks;
using ISEP_Project.WebApi.Domain.Entities;
using ISEP_Project.WebApi.DTOs;

namespace ISEP_Project.WebApi.Repositories
{
    public interface IPatientRepository
    {
        public interface IKlantRepository
    {
        void Add(Patient k);
        void Update(Patient k);

        Patient GetById(int id);
        IEnumerable<Patient> GetAll();
        bool Delete(int id);

        IEnumerable<Patient> Search(SearchOptionsPatient options);
    }
    }
}
