using System;
using System.Collections.Generic;

namespace Lab05RQuispe.Models;

public partial class profesore
{
    public int id_profesor { get; set; }

    public string nombre { get; set; } = null!;

    public string? especialidad { get; set; }

    public string? correo { get; set; }
}
