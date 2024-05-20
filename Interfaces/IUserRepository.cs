using DentalClinic.Models;

namespace DentalClinic.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();

        User GetUserByEmailAndPassword(string email, string password);

        User RegisterUser(User user);
    }
}

