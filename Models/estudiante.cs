using System;
using System.Collections.Generic;

namespace Lab05RQuispe.Models;

public partial class estudiante
{
    public int id_estudiante { get; set; }

    public string nombre { get; set; } = null!;

    public string? apellido { get; set; }

    public int? edad { get; set; }

    public string? direccion { get; set; }

    public string? telefono { get; set; }

    public string? correo { get; set; }

    public virtual ICollection<Asistencia> asistencia { get; set; } = new List<Asistencia>();

    public virtual ICollection<evaluacione> evaluaciones { get; set; } = new List<evaluacione>();

    public virtual ICollection<matricula> matriculas { get; set; } = new List<matricula>();
}
