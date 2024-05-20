using DentalClinic.Data;
using DentalClinic.Interfaces;
using DentalClinic.Models;

namespace DentalClinic.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DentalClinicContext _context;
        public UserRepository(DentalClinicContext context) 
        {
            _context = context;
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public User RegisterUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
