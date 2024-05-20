using DentalClinic.Models;

namespace DentalClinic.Interfaces
{
    public interface IClinicRepository
    {
        ICollection<Clinic> GetClinics();

        Clinic GetClinicByName(string name);

        Clinic AddClinic(Clinic clinic);

        Clinic UpdateClinic(Clinic clinic);
    }
}
