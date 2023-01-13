using Domain.Logic.Interfaces;
using Domain.Models;

namespace domain.Logic.Interfaces
{
    public interface ISpecializationRepository : IRepository<Specialization>
    {
        public Specialization? Get(string name);
    }
}