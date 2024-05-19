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
    }
}
