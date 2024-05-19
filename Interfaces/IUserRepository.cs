using DentalClinic.Models;

namespace DentalClinic.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
    }
}

