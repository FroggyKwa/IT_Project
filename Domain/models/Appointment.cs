﻿using Domain.Logic;

namespace Domain.Models
{
    public class Appointment
    {
        public int Id;
        public DateTime StartTime;
        public DateTime EndTime;
        public int PatientId;
        public int DoctorId;

        public Appointment(int id, DateTime startTime, DateTime endTime, int patientId, int doctorId)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            PatientId = patientId;
            DoctorId = doctorId;
        }

            public Appointment(DateTime startTime, DateTime endTime, int patientId, int doctorId)
        : this(0, startTime, endTime, patientId, doctorId) { }

        public Appointment() : this(0, DateTime.MinValue, DateTime.MinValue, 0, 0) { }
        public Result IsValid()
        {
            if (Id < 0)
                return Result.Fail("Incorrect ID");
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
