using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Employee_Signing_System.Models.Entity;

public partial class EmployeeSigningSystemContext : DbContext
{
    public EmployeeSigningSystemContext()
    {
    }

    public EmployeeSigningSystemContext(DbContextOptions<EmployeeSigningSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeStandardVert> EmployeeStandardVerts { get; set; }

    public virtual DbSet<EmployeeTempBadge> EmployeeTempBadges { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer(connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeStandardVert>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EmployeeStandardVert_1");

            entity.ToTable("EmployeeStandardVert");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.EFirstName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("e_FirstName");
            entity.Property(e => e.ELastName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("e_LastName");
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(200)
                .IsFixedLength()
                .HasColumnName("photoUrl");
        });

        modelBuilder.Entity<EmployeeTempBadge>(entity =>
        {
            entity.ToTable("EmployeeTempBadge");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.AssignT).HasColumnType("datetime");
            entity.Property(e => e.EmployeeFirstName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.EmployeeLastName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.SignInT).HasColumnType("datetime");
            entity.Property(e => e.SignOutT).HasColumnType("datetime");
            entity.Property(e => e.TempBadge)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
