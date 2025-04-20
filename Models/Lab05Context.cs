using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab05RQuispe.Models;

public partial class Lab05Context : DbContext
{
    public Lab05Context(DbContextOptions<Lab05Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencia> asistencias { get; set; }

    public virtual DbSet<curso> cursos { get; set; }

    public virtual DbSet<estudiante> estudiantes { get; set; }

    public virtual DbSet<evaluacione> evaluaciones { get; set; }

    public virtual DbSet<materia> materias { get; set; }

    public virtual DbSet<matricula> matriculas { get; set; }

    public virtual DbSet<profesore> profesores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.id_asistencia).HasName("PRIMARY");

            entity.HasIndex(e => e.id_curso, "id_curso");

            entity.HasIndex(e => e.id_estudiante, "id_estudiante");

            entity.Property(e => e.estado).HasMaxLength(20);

            entity.HasOne(d => d.id_cursoNavigation).WithMany(p => p.asistencia)
                .HasForeignKey(d => d.id_curso)
                .HasConstraintName("asistencias_ibfk_2");

            entity.HasOne(d => d.id_estudianteNavigation).WithMany(p => p.asistencia)
                .HasForeignKey(d => d.id_estudiante)
                .HasConstraintName("asistencias_ibfk_1");
        });

        modelBuilder.Entity<curso>(entity =>
        {
            entity.HasKey(e => e.id_curso).HasName("PRIMARY");

            entity.Property(e => e.descripcion).HasColumnType("text");
            entity.Property(e => e.nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<estudiante>(entity =>
        {
            entity.HasKey(e => e.id_estudiante).HasName("PRIMARY");

            entity.Property(e => e.apellido).HasMaxLength(100);
            entity.Property(e => e.correo).HasMaxLength(100);
            entity.Property(e => e.direccion).HasMaxLength(255);
            entity.Property(e => e.nombre).HasMaxLength(100);
            entity.Property(e => e.telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<evaluacione>(entity =>
        {
            entity.HasKey(e => e.id_evaluacion).HasName("PRIMARY");

            entity.HasIndex(e => e.id_curso, "id_curso");

            entity.HasIndex(e => e.id_estudiante, "id_estudiante");

            entity.Property(e => e.calificacion).HasPrecision(5, 2);

            entity.HasOne(d => d.id_cursoNavigation).WithMany(p => p.evaluaciones)
                .HasForeignKey(d => d.id_curso)
                .HasConstraintName("evaluaciones_ibfk_2");

            entity.HasOne(d => d.id_estudianteNavigation).WithMany(p => p.evaluaciones)
                .HasForeignKey(d => d.id_estudiante)
                .HasConstraintName("evaluaciones_ibfk_1");
        });

        modelBuilder.Entity<materia>(entity =>
        {
            entity.HasKey(e => e.id_materia).HasName("PRIMARY");

            entity.HasIndex(e => e.id_curso, "id_curso");

            entity.Property(e => e.descripcion).HasColumnType("text");
            entity.Property(e => e.nombre).HasMaxLength(100);

            entity.HasOne(d => d.id_cursoNavigation).WithMany(p => p.materia)
                .HasForeignKey(d => d.id_curso)
                .HasConstraintName("materias_ibfk_1");
        });

        modelBuilder.Entity<matricula>(entity =>
        {
            entity.HasKey(e => e.id_matricula).HasName("PRIMARY");

            entity.HasIndex(e => e.id_curso, "id_curso");

            entity.HasIndex(e => e.id_estudiante, "id_estudiante");

            entity.Property(e => e.semestre).HasMaxLength(20);

            entity.HasOne(d => d.id_cursoNavigation).WithMany(p => p.matriculas)
                .HasForeignKey(d => d.id_curso)
                .HasConstraintName("matriculas_ibfk_2");

            entity.HasOne(d => d.id_estudianteNavigation).WithMany(p => p.matriculas)
                .HasForeignKey(d => d.id_estudiante)
                .HasConstraintName("matriculas_ibfk_1");
        });

        modelBuilder.Entity<profesore>(entity =>
        {
            entity.HasKey(e => e.id_profesor).HasName("PRIMARY");

            entity.Property(e => e.correo).HasMaxLength(100);
            entity.Property(e => e.especialidad).HasMaxLength(100);
            entity.Property(e => e.nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
