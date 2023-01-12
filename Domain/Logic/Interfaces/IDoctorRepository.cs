using Domain.Models;

namespace Domain.Logic.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<Doctor>? getDoctor(Specialization specialization);
    }
}
