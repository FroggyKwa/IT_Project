using Domain.Logic;

namespace Domain.Models
{
    public class Appointment
    {
        public DateTime StartTime;
        public DateTime EndTime;
        public int PatientId;
        public int DoctorId;

        public Appointment(DateTime startTime, DateTime endTime, int patientId, int doctorId)
        {
            StartTime = startTime;
            EndTime = endTime;
            PatientId = patientId;
            DoctorId = doctorId;
        }
        public Appointment() : this(DateTime.MinValue, DateTime.MinValue, 0, 0) { }

        public Result IsValid()
        {
            if (PatientId < 0)
                return Result.Fail("Incorrect patient ID");
            if (DoctorId < 0)
                return Result.Fail("Incorrect doctor ID");
            if (StartTime > EndTime)
                return Result.Fail("Incorrect time provided");
            return Result.Ok();
        }
    }
}
