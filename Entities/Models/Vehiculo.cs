using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Vehiculo
{
    public int Id { get; set; }

    public string? Marca { get; set; }

    public string? NombreVehiculo { get; set; }

    public decimal? Precio { get; set; }
}
