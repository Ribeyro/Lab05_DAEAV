using System;
using System.Collections.Generic;

namespace Lab05RQuispe.Models;

public partial class Profesore
{
    public int IdProfesor { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Especialidad { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
