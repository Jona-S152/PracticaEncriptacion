using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Profesione
{
    public int Id { get; set; }

    public string? NombreProfesion { get; set; }

    public string? NombreProfesional { get; set; }

    public string? ApellidoProfesional { get; set; }

    public int? Edad { get; set; }
}
