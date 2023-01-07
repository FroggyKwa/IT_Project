using Domain.Models;

namespace Domain.Logic.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        bool createDoctor(Doctor doctor);
        bool deleteDoctor(Doctor doctor);
        IEnumerable<Doctor> GelAllDoctors();
        Doctor? getDoctor(int id);
        Doctor? getDoctor(Specialization specialization);
    }
}
