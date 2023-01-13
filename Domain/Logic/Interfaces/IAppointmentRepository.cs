using Domain.Models;

namespace Domain.Logic.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IEnumerable<Appointment> GetAppointments(int DoctorId);
        IEnumerable<Appointment> GetAppointments(Specialization specialization);
    }
}
