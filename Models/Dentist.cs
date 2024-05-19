using System;
using System.Collections.Generic;

namespace DentalClinic.Models;

public partial class Dentist
{
    public int DentistId { get; set; }

    public int ClinicId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string ProfilePicture { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Clinic Clinic { get; set; } = null!;

    public virtual ICollection<DentistWorkSlot> DentistWorkSlots { get; set; } = new List<DentistWorkSlot>();

    public virtual User User { get; set; } = null!;
}
