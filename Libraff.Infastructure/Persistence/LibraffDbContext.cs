using System.Reflection;

namespace Libraff.Infrastructure.Persistence;

public partial class LibraffDbContext : DbContext
{
    public LibraffDbContext()
    {
    }

    public LibraffDbContext(DbContextOptions<LibraffDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BranchEntity> Branches { get; set; }

    public virtual DbSet<BranchPositionLimitEntity> BranchPositionLimits { get; set; }


    public virtual DbSet<EmploymentHistoryEntity> EmploymentHistories { get; set; }

    public virtual DbSet<PersonEntity> Persons { get; set; }

    public virtual DbSet<PositionEntity> Positions { get; set; }

    public virtual DbSet<RoleEntity> Roles { get; set; }

    public virtual DbSet<UserEntity> Users { get; set; }    public virtual DbSet<BranchPositionSalaryLimitEntity> BranchPositionSalaryLimits { get; set; }

    public virtual DbSet<AuthorEntity> Authors { get; set; }

    public virtual DbSet<BookEntity> Books { get; set; }

    public virtual DbSet<GenreEntity> Genres { get; set; }
    public virtual DbSet<BonusDetailEntity> BonusDetails { get; set; }

    public virtual DbSet<BonusEntity> Bonuses { get; set; }

    public virtual DbSet<BranchDeliveriesHistoryEntity> BranchDeliveriesHistories { get; set; }

    public virtual DbSet<BranchStockEntity> BranchStocks { get; set; }

    public virtual DbSet<BranchTransferEntity> BranchTransfers { get; set; }

    public virtual DbSet<DiscountTypeEntity> DiscountTypes { get; set; }

    public virtual DbSet<DiscountEntity> DiscountsV1s { get; set; }

    public virtual DbSet<SalesRecordEntity> SalesRecords { get; set; }

    public virtual DbSet<SalesRecordDetailEntity> SalesRecordDetails { get; set; }

    public virtual DbSet<SellingPriceEntity> SellingPrices { get; set; }

    public virtual DbSet<StockEntity> Stocks { get; set; }

    public virtual DbSet<SupplyEntity> Supplies { get; set; }

    public virtual DbSet<SupplyDetailEntity> SupplyDetails { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<BranchEntity>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("branches_pkey");

    //        entity.ToTable("branches", "organization");

    //        entity.HasIndex(e => e.Code, "branches_code_key").IsUnique();

    //        entity.Property(e => e.Id).HasColumnName("id");
    //        entity.Property(e => e.Code)
    //            .HasMaxLength(20)
    //            .HasColumnName("code");
    //        entity.Property(e => e.ContactNumber)
    //            .HasMaxLength(20)
    //            .HasColumnName("contact_number");
    //        entity.Property(e => e.Description).HasColumnName("description");
    //        entity.Property(e => e.Location)
    //            .HasMaxLength(200)
    //            .HasColumnName("location");
    //        entity.Property(e => e.Name)
    //            .HasMaxLength(100)
    //            .HasColumnName("name");
    //    });

    //    modelBuilder.Entity<BranchPositionLimitEntity>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("branch_position_limits_pkey");

    //        entity.ToTable("branch_position_limits", "organization");

    //        entity.HasIndex(e => new { e.BranchId, e.PositionId }, "branch_position_limits_branch_id_position_id_key").IsUnique();

    //        entity.Property(e => e.Id).HasColumnName("id");
    //        entity.Property(e => e.BranchId).HasColumnName("branch_id");
    //        entity.Property(e => e.MaxEmployeesCount).HasColumnName("max_employees_count");
    //        entity.Property(e => e.PositionId).HasColumnName("position_id");

    //        entity.HasOne(d => d.Branch).WithMany(p => p.BranchPositionLimits)
    //            .HasForeignKey(d => d.BranchId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("branch_position_limits_branch_id_fkey");

    //        entity.HasOne(d => d.Position).WithMany(p => p.BranchPositionLimits)
    //            .HasForeignKey(d => d.PositionId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("branch_position_limits_position_id_fkey");
    //    });

    //    modelBuilder.Entity<BranchPositionSalaryLimitEntity>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("branch_position_salary_limits_pkey");

    //        entity.ToTable("branch_position_salary_limits", "organization");

    //        entity.HasIndex(e => new { e.BranchId, e.PositionId }, "branch_position_salary_limits_branch_id_position_id_key").IsUnique();

    //        entity.Property(e => e.Id).HasColumnName("id");
    //        entity.Property(e => e.BranchId).HasColumnName("branch_id");
    //        entity.Property(e => e.MaxSalary)
    //            .HasPrecision(10, 2)
    //            .HasColumnName("max_salary");
    //        entity.Property(e => e.MinSalary)
    //            .HasPrecision(10, 2)
    //            .HasColumnName("min_salary");
    //        entity.Property(e => e.PositionId).HasColumnName("position_id");

    //        entity.HasOne(d => d.Branch).WithMany(p => p.BranchPositionSalaryLimits)
    //            .HasForeignKey(d => d.BranchId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("branch_position_salary_limits_branch_id_fkey");

    //        entity.HasOne(d => d.Position).WithMany(p => p.BranchPositionSalaryLimits)
    //            .HasForeignKey(d => d.PositionId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("branch_position_salary_limits_position_id_fkey");
    //    });

    //    modelBuilder.Entity<EmploymentHistoryEntity>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("employment_history_pkey");

    //        entity.ToTable("employment_history", "organization");

    //        entity.Property(e => e.Id).HasColumnName("id");
    //        entity.Property(e => e.BranchId).HasColumnName("branch_id");
    //        entity.Property(e => e.PersonId).HasColumnName("person_id");
    //        entity.Property(e => e.PositionId).HasColumnName("position_id");
    //        entity.Property(e => e.Salary)
    //            .HasPrecision(12, 2)
    //            .HasColumnName("salary");
    //        entity.Property(e => e.WorkEndDate).HasColumnName("work_end_date");
    //        entity.Property(e => e.WorkStartDate).HasColumnName("work_start_date");

    //        entity.HasOne(d => d.Branch).WithMany(p => p.EmploymentHistories)
    //            .HasForeignKey(d => d.BranchId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("employment_history_branch_id_fkey");

    //        entity.HasOne(d => d.Person).WithMany(p => p.EmploymentHistories)
    //            .HasForeignKey(d => d.PersonId)
    //            .HasConstraintName("employment_history_person_id_fkey");

    //        entity.HasOne(d => d.Position).WithMany(p => p.EmploymentHistories)
    //            .HasForeignKey(d => d.PositionId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("employment_history_position_id_fkey");
    //    });

    //    modelBuilder.Entity<PersonEntity>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("persons_pkey");

    //        entity.ToTable("persons", "organization");

    //        entity.HasIndex(e => e.Pin, "persons_pin_key").IsUnique();

    //        entity.Property(e => e.Id).HasColumnName("id");
    //        entity.Property(e => e.ContactNumber)
    //            .HasMaxLength(20)
    //            .HasColumnName("contact_number");
    //        entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
    //        entity.Property(e => e.FirstName)
    //            .HasMaxLength(40)
    //            .HasColumnName("first_name");
    //        entity.Property(e => e.InsertedDate)
    //            .HasDefaultValueSql("CURRENT_TIMESTAMP")
    //            .HasColumnType("timestamp without time zone")
    //            .HasColumnName("inserted_date");
    //        entity.Property(e => e.LastName)
    //            .HasMaxLength(50)
    //            .HasColumnName("last_name");
    //        entity.Property(e => e.Patronymic)
    //            .HasMaxLength(40)
    //            .HasColumnName("patronymic");
    //        entity.Property(e => e.Pin)
    //            .HasMaxLength(7)
    //            .HasColumnName("pin");
    //        entity.Property(e => e.ResidentialAddress)
    //            .HasMaxLength(150)
    //            .HasColumnName("residential_address");
    //        entity.Property(e => e.UpdatedDate)
    //            .HasColumnType("timestamp without time zone")
    //            .HasColumnName("updated_date");
    //    });

    //    modelBuilder.Entity<PositionEntity>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("positions_pkey");

    //        entity.ToTable("positions", "organization");

    //        entity.HasIndex(e => e.Name, "positions_name_key").IsUnique();

    //        entity.Property(e => e.Id).HasColumnName("id");
    //        entity.Property(e => e.Name)
    //            .HasMaxLength(100)
    //            .HasColumnName("name");
    //        entity.Property(e => e.Order).HasColumnName("order");
    //    });

    //    modelBuilder.Entity<RoleEntity>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("roles_pk");

    //        entity.ToTable("roles", "organization");

    //        entity.HasIndex(e => e.Name, "roles_unique").IsUnique();

    //        entity.Property(e => e.Id).HasColumnName("id");
    //        entity.Property(e => e.Description)
    //            .HasMaxLength(100)
    //            .HasColumnName("description");
    //        entity.Property(e => e.Name)
    //            .HasMaxLength(50)
    //            .HasColumnName("name");
    //    });

    //    modelBuilder.Entity<UserEntity>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("users_pk");

    //        entity.ToTable("users", "organization");

    //        entity.HasIndex(e => e.Username, "users_unique").IsUnique();

    //        entity.HasIndex(e => e.EmailAddress, "users_unique_1").IsUnique();

    //        entity.Property(e => e.Id).HasColumnName("id");
    //        entity.Property(e => e.EmailAddress)
    //            .HasMaxLength(100)
    //            .HasColumnName("email_address");
    //        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
    //        entity.Property(e => e.IsActive)
    //            .HasDefaultValue(true)
    //            .HasColumnName("is_active");
    //        entity.Property(e => e.PasswordHashed)
    //            .HasMaxLength(100)
    //            .HasColumnName("password_hashed");
    //        entity.Property(e => e.RoleId).HasColumnName("role_id");
    //        entity.Property(e => e.Username)
    //            .HasMaxLength(50)
    //            .HasColumnName("username");
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
