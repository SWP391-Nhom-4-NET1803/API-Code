using System;
using System.Collections.Generic;

namespace DentalClinic.Models;

public partial class ClinicCertification
{
    public int Id { get; set; }

    public int ClinicId { get; set; }

    public int CertificationNumber { get; set; }

    public string CertificationImg { get; set; } = null!;

    public virtual Clinic Clinic { get; set; } = null!;
}
