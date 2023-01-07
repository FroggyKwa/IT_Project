using Domain.Logic;

namespace Domain.Models
{
    public class Schedule
    {
        public int DoctorId;
        public DateTime StartTime;
        public DateTime EndTime;

        public Result IsValid()
        {
            if (DoctorId < 0)
                return Result.Fail("Incorrect doctor id");
            if (StartTime > EndTime)
                return Result.Fail("Incorrect time");
            return Result.Ok();


        }
    }
}