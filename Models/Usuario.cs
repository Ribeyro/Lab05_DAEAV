using System;
using System.Collections.Generic;

namespace Lab05RQuispe.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    public virtual ICollection<Profesore> Profesores { get; set; } = new List<Profesore>();
}
