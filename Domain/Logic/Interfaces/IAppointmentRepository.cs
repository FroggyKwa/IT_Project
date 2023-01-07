using Domain.Models;

namespace Domain.Logic.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        bool Save(Appointment appointment);
        IEnumerable<Appointment> GetAppointments(int DoctorId);
        IEnumerable<Appointment> GetAppointments(Specialization specialization);
    }
}
