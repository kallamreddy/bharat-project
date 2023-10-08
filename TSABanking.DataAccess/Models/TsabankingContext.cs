using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TSABanking.DataAccess.Models;

public partial class TsabankingContext : DbContext
{
    public TsabankingContext()
    {
    }

    public TsabankingContext(DbContextOptions<TsabankingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobChangeQueue> JobChangeQueues { get; set; }

    public virtual DbSet<PickListMaster> PickListMasters { get; set; }

    public virtual DbSet<PickListType> PickListTypes { get; set; }

    public virtual DbSet<TerminationQueue> TerminationQueues { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserBank> UserBanks { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TSABanking;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bank__3214EC073EC1999B");

            entity.ToTable("Bank");

            entity.Property(e => e.Abreviation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BankName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.PlatformNavigation).WithMany(p => p.Banks)
                .HasForeignKey(d => d.Platform)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bank__Platform__3E52440B");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company__3214EC07373C73E1");

            entity.ToTable("Company");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Job__3214EC0707BA922A");

            entity.ToTable("Job");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<JobChangeQueue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobChang__3214EC07F2DFA696");

            entity.ToTable("JobChangeQueue");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.NewJob).WithMany(p => p.JobChangeQueueNewJobs)
                .HasForeignKey(d => d.NewJobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JobChange__NewJo__5165187F");

            entity.HasOne(d => d.OldJob).WithMany(p => p.JobChangeQueueOldJobs)
                .HasForeignKey(d => d.OldJobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JobChange__OldJo__5070F446");

            entity.HasOne(d => d.SuperVisor).WithMany(p => p.JobChangeQueueSuperVisors)
                .HasForeignKey(d => d.SuperVisorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JobChange__Super__4F7CD00D");

            entity.HasOne(d => d.User).WithMany(p => p.JobChangeQueueUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JobChange__UserI__4E88ABD4");
        });

        modelBuilder.Entity<PickListMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PickList__3214EC0733489F93");

            entity.ToTable("PickListMaster");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.PickListMasters)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PickListMa__Type__38996AB5");
        });

        modelBuilder.Entity<PickListType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PickList__3214EC0783708D57");

            entity.ToTable("PickListType");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TerminationQueue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Terminat__3214EC07DB69484F");

            entity.ToTable("TerminationQueue");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Bank).WithMany(p => p.TerminationQueues)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Terminati__BankI__49C3F6B7");

            entity.HasOne(d => d.Company).WithMany(p => p.TerminationQueues)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Terminati__Compa__48CFD27E");

            entity.HasOne(d => d.SuperVisor).WithMany(p => p.TerminationQueueSuperVisors)
                .HasForeignKey(d => d.SuperVisorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Terminati__Super__47DBAE45");

            entity.HasOne(d => d.User).WithMany(p => p.TerminationQueueUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Terminati__UserI__46E78A0C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0773D18684");

            entity.ToTable("User");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleInitial)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.UserTypeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__UserType__3B75D760");
        });

        modelBuilder.Entity<UserBank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserBank__3214EC077332213B");

            entity.ToTable("UserBank");

            entity.HasOne(d => d.Bank).WithMany(p => p.UserBanks)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserBank__BankId__4222D4EF");

            entity.HasOne(d => d.User).WithMany(p => p.UserBanks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserBank__UserId__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
