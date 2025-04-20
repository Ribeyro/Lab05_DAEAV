using System;
using System.Collections.Generic;

namespace Lab05RQuispe.Models;

public partial class matricula
{
    public int id_matricula { get; set; }

    public int? id_estudiante { get; set; }

    public int? id_curso { get; set; }

    public string? semestre { get; set; }

    public virtual curso? id_cursoNavigation { get; set; }

    public virtual estudiante? id_estudianteNavigation { get; set; }
}
