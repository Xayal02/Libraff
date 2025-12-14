using System;
using System.Collections.Generic;

namespace Libraff.Infrastructure.Persistence.Entities;

public partial class BranchDeliveriesHistoryEntity
{
    public int Id { get; set; }

    public int BranchStockId { get; set; }

    public int DeliveredCount { get; set; }

    public DateOnly DeliveryDate { get; set; }
    public virtual BranchStockEntity BranchStock { get; set; } = null!;
}
