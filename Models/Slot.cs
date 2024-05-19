using System;
using System.Collections.Generic;

namespace DentalClinic.Models;

public partial class Slot
{
    public int SlotId { get; set; }

    public int ClinicId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int MaximumCustomer { get; set; }

    public string DayInWeek { get; set; } = null!;

    public DateOnly Date { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Clinic Clinic { get; set; } = null!;

    public virtual ICollection<DentistWorkSlot> DentistWorkSlots { get; set; } = new List<DentistWorkSlot>();
}
