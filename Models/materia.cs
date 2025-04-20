using System;
using System.Collections.Generic;

namespace Lab05RQuispe.Models;

public partial class materia
{
    public int id_materia { get; set; }

    public int? id_curso { get; set; }

    public string nombre { get; set; } = null!;

    public string? descripcion { get; set; }

    public virtual curso? id_cursoNavigation { get; set; }
}
