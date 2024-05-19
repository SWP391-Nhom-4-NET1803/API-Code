using System;
using System.Collections.Generic;

namespace DentalClinic.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int DentistId { get; set; }

    public int SlotId { get; set; }

    public string Status { get; set; } = null!;

    public string Note { get; set; } = null!;

    public int ClinicServiceId { get; set; }

    public string IsRepeated { get; set; } = null!;

    public string AppointmentResult { get; set; } = null!;

    public virtual ClinicService ClinicService { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Dentist Dentist { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Slot Slot { get; set; } = null!;
}
