using Domain.Models;


namespace Domain.Logic.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User? GetUserByLogin(string login);
    }
}