using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Capitale
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Acronimo { get; set; }

    public string? CodigoPostal { get; set; }

    public int? PaisId { get; set; }

    public virtual Paise? Pais { get; set; }
}
