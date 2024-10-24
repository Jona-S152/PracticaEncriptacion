using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities.Models;

public partial class Paise
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Acronimo { get; set; }

    public string? CodigoPais { get; set; }

    [JsonIgnore]
    public virtual ICollection<Capitale> Capitales { get; set; } = new List<Capitale>();
}
