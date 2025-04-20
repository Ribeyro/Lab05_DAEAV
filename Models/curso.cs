using System;
using System.Collections.Generic;

namespace Lab05RQuispe.Models;

public partial class curso
{
    public int id_curso { get; set; }

    public string nombre { get; set; } = null!;

    public string? descripcion { get; set; }

    public int creditos { get; set; }

    public virtual ICollection<Asistencia> asistencia { get; set; } = new List<Asistencia>();

    public virtual ICollection<evaluacione> evaluaciones { get; set; } = new List<evaluacione>();

    public virtual ICollection<materia> materia { get; set; } = new List<materia>();

    public virtual ICollection<matricula> matriculas { get; set; } = new List<matricula>();
}
