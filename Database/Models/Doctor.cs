using Domain.Models;

using SpecializationDB = Database.Models.Specialization;

namespace Database.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public int SpecializationId;
        public string Fullname { get; set; } = string.Empty;
        
    }
}
