using System;
using System.Collections.Generic;

namespace DentalClinic.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int AppointmentId { get; set; }

    public decimal Amount { get; set; }

    public string Status { get; set; } = null!;

    public virtual Appointment Appointment { get; set; } = null!;
}
