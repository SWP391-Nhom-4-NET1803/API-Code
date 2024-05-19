using System;
using System.Collections.Generic;

namespace DentalClinic.Models;

public partial class ClinicService
{
    public int ClinicServiceId { get; set; }

    public int ServiceId { get; set; }

    public int ClinicId { get; set; }

    public decimal Price { get; set; }

    public string ServiceDescription { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Clinic Clinic { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
