using System;
using System.Collections.Generic;

namespace Lab05RQuispe.Models;

public partial class Asistencia
{
    public int id_asistencia { get; set; }

    public int? id_estudiante { get; set; }

    public int? id_curso { get; set; }

    public DateOnly? fecha { get; set; }

    public string? estado { get; set; }

    public virtual curso? id_cursoNavigation { get; set; }

    public virtual estudiante? id_estudianteNavigation { get; set; }
}
