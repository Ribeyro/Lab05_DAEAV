using System;
using System.Collections.Generic;

namespace Lab05RQuispe.Models;

public partial class Estudiante
{
    public int IdEstudiante { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public int? Edad { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public int? IdUsuario { get; set; }

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual ICollection<Evaluacione> Evaluaciones { get; set; } = new List<Evaluacione>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
