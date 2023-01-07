using Domain.Logic;
using Domain.Models;
using Domain.Logic.Interfaces;

namespace Domain.UseCases
{
    public class DoctorInteractor
    {
        private readonly IDoctorRepository _db;
        private readonly IAppointmentRepository _apdb;
        public DoctorInteractor(IDoctorRepository db, IAppointmentRepository apdb)
        {
            _db = db;
            _apdb = apdb;
        }

        public Result<Doctor> CreateDoctor(Doctor doctor)
        {
            if (doctor.IsValid().isFailure)
                return Result.Fail<Doctor>("Invalid doctor: " + doctor.IsValid().Error);
            return _db.createDoctor(doctor) ? Result.Ok(doctor) : Result.Fail<Doctor>("Cannot create doctor");
        }

        public Result<Doctor> GetDoctor(int id)
        {
            if (id < 0)
                return Result.Fail<Doctor>("Invalid id");

            var doctor = _db.getDoctor(id);

            return doctor != null ? Result.Ok(doctor) : Result.Fail<Doctor>("Doctor not found");
        }
        public Result<Doctor> GetDoctor(Specialization specialization)
        {
            var result = specialization.IsValid();
            if (result.isFailure)
                return Result.Fail<Doctor>("Incorrect specialization: " + result.Error);

            var doctor = _db.getDoctor(specialization);

            return doctor != null ? Result.Ok(doctor) : Result.Fail<Doctor>("Doctor not found");
        }

        public Result<Doctor> deleteDoctor(int id)
        {
            if (_apdb.GetAppointments(id).Any())
                return Result.Fail<Doctor>("Cannot delete doctor. Doctor has appointments");
            var result = GetDoctor(id);
            if (result.isFailure)
                return Result.Fail<Doctor>(result.Error);
            return _db.deleteDoctor(GetDoctor(id).Value) ? result : Result.Fail<Doctor>("Cannot delete the doctor");
        }
    }
}
