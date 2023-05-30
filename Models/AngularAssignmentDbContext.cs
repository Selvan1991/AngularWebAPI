using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentDetail.Models;

public partial class AngularAssignmentDbContext : DbContext
{
    public AngularAssignmentDbContext()
    {
    }

    public AngularAssignmentDbContext(DbContextOptions<AngularAssignmentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentDetails> StudentDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KANINI-LTP-768;Database=AngularAssignmentDB;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;UID=sa;Password=Selvan@1989;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD8A5B5C40");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC276391665B");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Course)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LocationInfo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TrainingMode)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StudentDetails>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__StudentD__32C52A79EB6683DD");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Course)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Percentage).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Specialization)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.StudentDetails)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentDetails_Department");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
