using Domain.Models;

namespace Domain.Logic.Interfaces
{
    public interface ISpecializationRepository : IRepository<Specialization>
    {
        public Specialization? Get(string name);
    }
}