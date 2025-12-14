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
}
