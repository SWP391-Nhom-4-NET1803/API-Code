using DentalClinic.Data;
using DentalClinic.Interfaces;
using DentalClinic.Models;

namespace DentalClinic.Repository
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly DentalClinicContext _context;
        public ClinicRepository(DentalClinicContext context)
        {
            _context = context;
        }
        public ICollection<Clinic> GetClinics()
        {
            return _context.Clinics.ToList();
        }
        public Clinic AddClinic(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            _context.SaveChanges();
            return clinic;
        }

        public Clinic UpdateClinic(Clinic clinic)
        {
            _context.Clinics.Update(clinic);
            _context.SaveChanges();
            return clinic;
        }

        public Clinic GetClinicByName(string name)
        {
            return _context.Clinics.FirstOrDefault(c => c.Name == name);
        }
    }
}
