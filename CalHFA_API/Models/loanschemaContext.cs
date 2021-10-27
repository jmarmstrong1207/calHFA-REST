using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CalHFA_API.Models
{
    public partial class loanschemaContext : DbContext
    {
        public loanschemaContext()
        {
        }

        public loanschemaContext(DbContextOptions<loanschemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<LoanType> LoanTypes { get; set; }
        public virtual DbSet<Loancategory> Loancategories { get; set; }
        public virtual DbSet<Loanstatus> Loanstatuses { get; set; }
        public virtual DbSet<Statuscode> Statuscodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=73.116.84.13;user=access;database=loanschema");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("loan");

                entity.HasIndex(e => e.LoanTypeId, "LoanTypeID_idx");

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.AnnualIncome).HasMaxLength(45);

                entity.Property(e => e.Balance).HasMaxLength(45);

                entity.Property(e => e.DeliveryDate).HasMaxLength(45);

                entity.Property(e => e.HouseholdCount).HasMaxLength(45);

                entity.Property(e => e.InsurerNum).HasMaxLength(45);

                entity.Property(e => e.InterestRate).HasColumnType("decimal(10,0)");

                entity.Property(e => e.LoanTypeId).HasColumnName("LoanTypeID");

                entity.Property(e => e.Lvratio)
                    .HasMaxLength(45)
                    .HasColumnName("LVRatio");

                entity.Property(e => e.ReservDateTime).HasMaxLength(45);

                entity.HasOne(d => d.LoanType)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.LoanTypeId)
                    .HasConstraintName("LoanTypeID");
            });

            modelBuilder.Entity<LoanType>(entity =>
            {
                entity.ToTable("loan_type");

                entity.HasIndex(e => e.LoanCategoryId, "L_idx");

                entity.Property(e => e.LoanTypeId).HasColumnName("LoanTypeID");

                entity.Property(e => e.Active).HasMaxLength(10);

                entity.Property(e => e.ActiveEndDate).HasMaxLength(45);

                entity.Property(e => e.ActiveRates).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.LoanCategoryId).HasColumnName("LoanCategoryID");

                entity.Property(e => e.LongDescription).HasMaxLength(200);

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.HasOne(d => d.LoanCategory)
                    .WithMany(p => p.LoanTypes)
                    .HasForeignKey(d => d.LoanCategoryId)
                    .HasConstraintName("LoanCategoryID");
            });

            modelBuilder.Entity<Loancategory>(entity =>
            {
                entity.ToTable("loancategory");

                entity.Property(e => e.LoanCategoryId).HasColumnName("LoanCategoryID");

                entity.Property(e => e.Description).HasMaxLength(45);
            });

            modelBuilder.Entity<Loanstatus>(entity =>
            {
                entity.ToTable("loanstatus");

                entity.HasIndex(e => e.LoanId, "LoanID_idx");

                entity.HasIndex(e => e.StatusCode, "StatusCode_idx");

                entity.Property(e => e.LoanStatusId).HasColumnName("LoanStatusID");

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.LoginDate).HasMaxLength(45);

                entity.Property(e => e.LoginName).HasMaxLength(45);

                entity.Property(e => e.StatusDate).HasMaxLength(45);

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.Loanstatuses)
                    .HasForeignKey(d => d.LoanId)
                    .HasConstraintName("LoanID");

                entity.HasOne(d => d.StatusCodeNavigation)
                    .WithMany(p => p.Loanstatuses)
                    .HasForeignKey(d => d.StatusCode)
                    .HasConstraintName("StatusCode");
            });

            modelBuilder.Entity<Statuscode>(entity =>
            {
                entity.HasKey(e => e.StatusCode1)
                    .HasName("PRIMARY");

                entity.ToTable("statuscode");

                entity.Property(e => e.StatusCode1).HasColumnName("StatusCode");

                entity.Property(e => e.BusinessUnit).HasMaxLength(45);

                entity.Property(e => e.ConversationCategoryId)
                    .HasMaxLength(100)
                    .HasColumnName("ConversationCategoryID");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.NotesAndAssumptions).HasMaxLength(400);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
