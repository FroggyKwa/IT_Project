using Domain.Logic;

namespace Domain.Models
{
    public class Schedule
    {
        public int Id;
        public int DoctorId;
        public DateTime StartTime;
        public DateTime EndTime;

        public Schedule(int doctorId, DateTime startTime, DateTime endTime)
        {
            DoctorId = doctorId;
            StartTime = startTime;
            EndTime = endTime;
        }

        public Schedule() : this(0, DateTime.MinValue, DateTime.MaxValue) { }

        public Result IsValid()
        {
            if (DoctorId < 0)
                return Result.Fail("Incorrect id");
            if (DoctorId < 0)
                return Result.Fail("Incorrect doctor id");
            if (StartTime > EndTime)
                return Result.Fail("Incorrect time");
            return Result.Ok();


        }
    }
}