using System;
using System.Collections.Generic;

namespace DentalClinic.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Sex { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual User User { get; set; } = null!;
}
