using Domain.Logic;
using Domain.Models;
using Domain.Logic.Interfaces;

namespace Domain.UseCases
{
    public class ScheduleInteractor
    {
        private readonly IScheduleRepository _db;
        
        public ScheduleInteractor(IScheduleRepository db)
        {
            _db = db;
        }

        public Result<Schedule> getSchedule(Doctor doctor)
        {
            var result = doctor.IsValid();
            if (result.isFailure)
                return Result.Fail<Schedule>("Cannot get schedule");
            return Result.Ok(_db.GetItem(doctor.Id)!);
        }
        
        public Result<Schedule> CreateSchedule(Doctor doctor, Schedule schedule)
        {
            var result = doctor.IsValid() & schedule.IsValid();
            if (!result)
                return Result.Fail<Schedule>("Cannot create schedule");
            if (_db.Create(schedule).Id >= 0)
            {
                _db.Save();
                return Result.Ok(schedule);
            }
            return Result.Fail<Schedule>("Unable to add schedule");
        }

    }
}
