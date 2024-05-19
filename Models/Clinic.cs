using System;
using System.Collections.Generic;

namespace DentalClinic.Models;

public partial class Clinic
{
    public int ClinicId { get; set; }

    public int ClinicOwnerId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public TimeOnly OpenHour { get; set; }

    public TimeOnly CloseHour { get; set; }

    public virtual ICollection<ClinicCertification> ClinicCertifications { get; set; } = new List<ClinicCertification>();

    public virtual User ClinicOwner { get; set; } = null!;

    public virtual ICollection<ClinicService> ClinicServices { get; set; } = new List<ClinicService>();

    public virtual ICollection<Dentist> Dentists { get; set; } = new List<Dentist>();

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();
}
