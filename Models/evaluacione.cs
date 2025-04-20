using System;
using System.Collections.Generic;

namespace Lab05RQuispe.Models;

public partial class evaluacione
{
    public int id_evaluacion { get; set; }

    public int? id_estudiante { get; set; }

    public int? id_curso { get; set; }

    public decimal? calificacion { get; set; }

    public DateOnly? fecha { get; set; }

    public virtual curso? id_cursoNavigation { get; set; }

    public virtual estudiante? id_estudianteNavigation { get; set; }
}
