using System;
using System.Collections.Generic;

namespace DentalClinic.Models;

public partial class User
{
    public int UserId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Clinic> Clinics { get; set; } = new List<Clinic>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Dentist> Dentists { get; set; } = new List<Dentist>();
}
