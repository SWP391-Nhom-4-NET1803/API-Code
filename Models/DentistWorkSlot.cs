using System;
using System.Collections.Generic;

namespace DentalClinic.Models;

public partial class DentistWorkSlot
{
    public int Id { get; set; }

    public int DentistId { get; set; }

    public int SlotId { get; set; }

    public virtual Dentist Dentist { get; set; } = null!;

    public virtual Slot Slot { get; set; } = null!;
}
