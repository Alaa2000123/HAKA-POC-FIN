using System;
using System.Collections.Generic;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Entity.Repository;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FleetManagement> FleetManagements { get; set; }

    public virtual DbSet<GeneralAction> GeneralActions { get; set; }

    public virtual DbSet<GeneralActionsHistory> GeneralActionsHistories { get; set; }

    public virtual DbSet<GeneralEmployee> GeneralEmployees { get; set; }

    public virtual DbSet<GeneralLookup> GeneralLookups { get; set; }

    public virtual DbSet<GeneralLookupsGroup> GeneralLookupsGroups { get; set; }

    public virtual DbSet<GeneralRequestsService> GeneralRequestsServices { get; set; }

    public virtual DbSet<GeneralServiceType> GeneralServiceTypes { get; set; }

    public virtual DbSet<GeneralStep> GeneralSteps { get; set; }

    public virtual DbSet<GenralService> GenralServices { get; set; }

    public virtual DbSet<GenralStatus> GenralStatuses { get; set; }

    public virtual DbSet<InsuranceCompanyType> InsuranceCompanyTypes { get; set; }

    public virtual DbSet<InsuranceInfo> InsuranceInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=154.12.237.206;Initial Catalog=Haka;User ID=zuhairi;Password=!@mr!D!@b;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FleetManagement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_fleetManagement");

            entity.HasOne(d => d.Employee).WithMany(p => p.FleetManagements).HasConstraintName("fk_fleetmanagement");

            entity.HasOne(d => d.FleetManagementType).WithMany(p => p.FleetManagements).HasConstraintName("fk_fleetmanagement_Lookup");

            entity.HasOne(d => d.Request).WithMany(p => p.FleetManagements).HasConstraintName("fk_fleetmanagement_RequestID");
        });

        modelBuilder.Entity<GeneralAction>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("pk_general_actions");
        });

        modelBuilder.Entity<GeneralActionsHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_general_actionsHistory");

            entity.HasOne(d => d.Action).WithMany(p => p.GeneralActionsHistories).HasConstraintName("fk_general_actionshistory_action");

            entity.HasOne(d => d.Request).WithMany(p => p.GeneralActionsHistories).HasConstraintName("fk_general_actionshistory_requestID");

            entity.HasOne(d => d.Step).WithMany(p => p.GeneralActionsHistories).HasConstraintName("fk_general_actionshistory_step");
        });

        modelBuilder.Entity<GeneralEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_general_employee");

            entity.HasOne(d => d.Lookup).WithMany(p => p.GeneralEmployees).HasConstraintName("fk_general_employee_lookup");

            entity.HasOne(d => d.Request).WithMany(p => p.GeneralEmployees).HasConstraintName("fk_general_employee_RequestID");
        });

        modelBuilder.Entity<GeneralLookup>(entity =>
        {
            entity.HasKey(e => e.Gnid).HasName("pk_general_lookups");

            entity.HasOne(d => d.Group).WithMany(p => p.GeneralLookups).HasConstraintName("fk_general_lookups_group");
        });

        modelBuilder.Entity<GeneralLookupsGroup>(entity =>
        {
            entity.HasKey(e => e.Gid).HasName("pk_general_lookupsGroups");
        });

        modelBuilder.Entity<GeneralRequestsService>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("pk_general_requests");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.GeneralRequestsServices).HasConstraintName("fk_general_requests");

            entity.HasOne(d => d.Status).WithMany(p => p.GeneralRequestsServices).HasConstraintName("fk_general_requests_status");

            entity.HasOne(d => d.Step).WithMany(p => p.GeneralRequestsServices).HasConstraintName("fk_general_requests_step");
        });

        modelBuilder.Entity<GeneralServiceType>(entity =>
        {
            entity.HasKey(e => e.Stid).HasName("pk_general_serviceType");

            entity.HasOne(d => d.Service).WithMany(p => p.GeneralServiceTypes).HasConstraintName("fk_general_servicetype_service");
        });

        modelBuilder.Entity<GeneralStep>(entity =>
        {
            entity.HasKey(e => e.Stid).HasName("pk_general_steps");
        });

        modelBuilder.Entity<GenralService>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("pk_genral_service");
        });

        modelBuilder.Entity<GenralStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_genral_status");
        });

        modelBuilder.Entity<InsuranceCompanyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_InsuranceCompanyType");
        });

        modelBuilder.Entity<InsuranceInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_InsuranceInfo");

            entity.HasOne(d => d.Employee).WithMany(p => p.InsuranceInfos).HasConstraintName("fk_insuranceinfo_Employee");

            entity.HasOne(d => d.InsuranceCompanyType).WithMany(p => p.InsuranceInfos).HasConstraintName("fk_insuranceinfo_InsuranceCompanyType");

            entity.HasOne(d => d.InsuranceType).WithMany(p => p.InsuranceInfos).HasConstraintName("fk_insuranceinfo_lookup");

            entity.HasOne(d => d.Request).WithMany(p => p.InsuranceInfos).HasConstraintName("fk_insuranceinfo_RequestID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
