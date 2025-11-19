//namespace Libraff.Infrastructure;

//public partial class LibraffV2Context : DbContext
//{
//    public LibraffV2Context()
//    {
//    }

//    public LibraffV2Context(DbContextOptions<LibraffV2Context> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<BonusDetail> BonusDetails { get; set; }

//    public virtual DbSet<Bonus> Bonuses { get; set; }

//    public virtual DbSet<BranchDeliveriesHistory> BranchDeliveriesHistories { get; set; }

//    public virtual DbSet<BranchStock> BranchStocks { get; set; }

//    public virtual DbSet<BranchTransfer> BranchTransfers { get; set; }

//    public virtual DbSet<DiscountType> DiscountTypes { get; set; }

//    public virtual DbSet<Discount> DiscountsV1s { get; set; }

//    public virtual DbSet<SalesRecord> SalesRecords { get; set; }

//    public virtual DbSet<SalesRecordDetail> SalesRecordDetails { get; set; }

//    public virtual DbSet<SellingPrice> SellingPrices { get; set; }

//    public virtual DbSet<Stock> Stocks { get; set; }

//    public virtual DbSet<Supply> Supplies { get; set; }

//    public virtual DbSet<SupplyDetail> SupplyDetails { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("Host=localhost;Database=libraff_v2;Username=postgres;Password=0702534040x");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<BonusDetail>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("bonus_details_pkey");

//            entity.ToTable("bonus_details", "sales");

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.BonusId).HasColumnName("bonus_id");
//            entity.Property(e => e.Percent)
//                .HasPrecision(5, 2)
//                .HasColumnName("percent");
//            entity.Property(e => e.PositionId).HasColumnName("position_id");
//            entity.Property(e => e.SalesMaxRange)
//                .HasPrecision(10, 2)
//                .HasColumnName("sales_max_range");
//            entity.Property(e => e.SalesMinRange)
//                .HasPrecision(10, 2)
//                .HasColumnName("sales_min_range");

//            entity.HasOne(d => d.Bonus).WithMany(p => p.BonusDetails)
//                .HasForeignKey(d => d.BonusId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("bonus_details_bonus_id_fkey");
//        });

//        modelBuilder.Entity<Bonus>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("bonuses_pkey");

//            entity.ToTable("bonuses", "sales");

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.ApplyToAllPositions)
//                .HasDefaultValue(false)
//                .HasColumnName("apply_to_all_positions");
//            entity.Property(e => e.BranchId).HasColumnName("branch_id");
//            entity.Property(e => e.IsActive)
//                .HasDefaultValue(true)
//                .HasColumnName("is_active");
//        });

//        modelBuilder.Entity<BranchDeliveriesHistory>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("newtable_pk");

//            entity.ToTable("branch_deliveries_history", "warehouse");

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.BranchId).HasColumnName("branch_id");
//            entity.Property(e => e.DeliveredCount).HasColumnName("delivered_count");
//            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
//            entity.Property(e => e.SupplyDetailId).HasColumnName("supply_detail_id");

//            entity.HasOne(d => d.SupplyDetail).WithMany(p => p.BranchDeliveriesHistories)
//                .HasForeignKey(d => d.SupplyDetailId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("fk_branch_deliveries_history_supply_detail");
//        });

//        modelBuilder.Entity<BranchStock>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("branch_stock_pk");

//            entity.ToTable("branch_stock", "warehouse");

//            entity.HasIndex(e => new { e.BranchId, e.SupplyDetailId }, "uq_branch_stock_branch_supply").IsUnique();

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.BranchId).HasColumnName("branch_id");
//            entity.Property(e => e.CurrentCount).HasColumnName("current_count");
//            entity.Property(e => e.SupplyDetailId).HasColumnName("supply_detail_id");

//            entity.HasOne(d => d.SupplyDetail).WithMany(p => p.BranchStocks)
//                .HasForeignKey(d => d.SupplyDetailId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("fk_branch_stock_supply_detail");
//        });

//        modelBuilder.Entity<BranchTransfer>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("branch_transfers_pkey");

//            entity.ToTable("branch_transfers", "warehouse");

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.ConfirmDate)
//                .HasColumnType("timestamp without time zone")
//                .HasColumnName("confirm_date");
//            entity.Property(e => e.ConfirmedCount).HasColumnName("confirmed_count");
//            entity.Property(e => e.ConfirmedUserId).HasColumnName("confirmed_user_id");
//            entity.Property(e => e.DeliveryDate)
//                .HasColumnType("timestamp without time zone")
//                .HasColumnName("delivery_date");
//            entity.Property(e => e.FromBranchId).HasColumnName("from_branch_id");
//            entity.Property(e => e.IsConfirmed).HasColumnName("is_confirmed");
//            entity.Property(e => e.IsDelivered)
//                .HasDefaultValue(false)
//                .HasColumnName("is_delivered");
//            entity.Property(e => e.RejectedUserId).HasColumnName("rejected_user_id");
//            entity.Property(e => e.RejectionReason)
//                .HasMaxLength(150)
//                .HasColumnName("rejection_reason");
//            entity.Property(e => e.RequestDate)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("timestamp without time zone")
//                .HasColumnName("request_date");
//            entity.Property(e => e.RequestedCount).HasColumnName("requested_count");
//            entity.Property(e => e.RequestedUserId).HasColumnName("requested_user_id");
//            entity.Property(e => e.SupplyDetailId).HasColumnName("supply_detail_id");
//            entity.Property(e => e.ToBranchId).HasColumnName("to_branch_id");

//            entity.HasOne(d => d.SupplyDetail).WithMany(p => p.BranchTransfers)
//                .HasForeignKey(d => d.SupplyDetailId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("branch_transfers_supply_detail_id_fkey");
//        });

//        modelBuilder.Entity<DiscountType>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("discount_types_pk");

//            entity.ToTable("discount_types", "sales");

//            entity.Property(e => e.Id)
//                .ValueGeneratedNever()
//                .HasColumnName("id");
//            entity.Property(e => e.Description)
//                .HasMaxLength(150)
//                .HasColumnName("description");
//            entity.Property(e => e.Name)
//                .HasMaxLength(40)
//                .HasColumnName("name");
//        });

//        modelBuilder.Entity<Discount>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("discounts_pk");

//            entity.ToTable("discounts_v1", "sales");

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.DiscountTypeId).HasColumnName("discount_type_id");
//            entity.Property(e => e.Percent)
//                .HasPrecision(2, 1)
//                .HasColumnName("percent");
//            entity.Property(e => e.ReferenceId).HasColumnName("reference_id");
//            entity.Property(e => e.ValidFrom)
//                .HasColumnType("timestamp without time zone")
//                .HasColumnName("valid_from");
//            entity.Property(e => e.ValidTo)
//                .HasColumnType("timestamp without time zone")
//                .HasColumnName("valid_to");
//        });

//        modelBuilder.Entity<SalesRecord>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("sales_records_pkey");

//            entity.ToTable("sales_records", "sales");

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.BranchId).HasColumnName("branch_id");
//            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
//            entity.Property(e => e.SaleDate)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("timestamp without time zone")
//                .HasColumnName("sale_date");
//        });

//        modelBuilder.Entity<SalesRecordDetail>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("sales_record_details_pkey");

//            entity.ToTable("sales_record_details", "sales");

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.FixedPrice)
//                .HasPrecision(10, 2)
//                .HasColumnName("fixed_price");
//            entity.Property(e => e.PriceAfterDiscount)
//                .HasPrecision(10, 2)
//                .HasColumnName("price_after_discount");
//            entity.Property(e => e.Quantity)
//                .HasDefaultValue((short)1)
//                .HasColumnName("quantity");
//            entity.Property(e => e.SalesRecordId).HasColumnName("sales_record_id");
//            entity.Property(e => e.SupplyDetailId).HasColumnName("supply_detail_id");

//            entity.HasOne(d => d.SalesRecord).WithMany(p => p.SalesRecordDetails)
//                .HasForeignKey(d => d.SalesRecordId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("sales_record_details_sales_record_id_fkey");

//            entity.HasOne(d => d.SupplyDetail).WithMany(p => p.SalesRecordDetails)
//                .HasForeignKey(d => d.SupplyDetailId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("sales_record_details_supply_detail_id_fkey");
//        });

//        modelBuilder.Entity<SellingPrice>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("selling_prices_pkey");

//            entity.ToTable("selling_prices", "sales");

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.BranchId).HasColumnName("branch_id");
//            entity.Property(e => e.Price)
//                .HasPrecision(10, 2)
//                .HasColumnName("price");
//            entity.Property(e => e.SupplyDetailId).HasColumnName("supply_detail_id");

//            entity.HasOne(d => d.SupplyDetail).WithMany(p => p.SellingPrices)
//                .HasForeignKey(d => d.SupplyDetailId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("selling_prices_supply_detail_id_fkey");
//        });

//        modelBuilder.Entity<Stock>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("stock_pk");

//            entity.ToTable("stock", "warehouse");

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.AvailableCount).HasColumnName("available_count");
//            entity.Property(e => e.ModifiedAt)
//                .HasColumnType("timestamp without time zone")
//                .HasColumnName("modified_at");
//            entity.Property(e => e.SupplyDetailId).HasColumnName("supply_detail_id");

//            entity.HasOne(d => d.SupplyDetail).WithMany(p => p.Stocks)
//                .HasForeignKey(d => d.SupplyDetailId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("fk_stock_supply_detail");
//        });

//        modelBuilder.Entity<Supply>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("supplies_pk");

//            entity.ToTable("supplies", "warehouse");

//            entity.HasIndex(e => e.InvoiceNumber, "supplies_unique").IsUnique();

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.CreatedAt)
//                .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                .HasColumnType("timestamp without time zone")
//                .HasColumnName("created_at");
//            entity.Property(e => e.InvoiceNumber)
//                .HasMaxLength(50)
//                .HasColumnName("invoice_number");
//            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
//            entity.Property(e => e.SupplyDate).HasColumnName("supply_date");
//        });

//        modelBuilder.Entity<SupplyDetail>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("supply_details_pk");

//            entity.ToTable("supply_details", "warehouse");

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.BookId).HasColumnName("book_id");
//            entity.Property(e => e.InitialCount).HasColumnName("initial_count");
//            entity.Property(e => e.PricePerBook)
//                .HasPrecision(10, 2)
//                .HasColumnName("price_per_book");
//            entity.Property(e => e.SupplyId).HasColumnName("supply_id");

//            entity.HasOne(d => d.Supply).WithMany(p => p.SupplyDetails)
//                .HasForeignKey(d => d.SupplyId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("fk_supply_details_supply");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
