﻿using System;
using System.Collections.Generic;

namespace PAW.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? UnitsInStock { get; set; }

    public DateTime? LastUpdated { get; set; }

    public DateTime? DateAdded { get; set; }

    public string? ModifiedBy { get; set; }
}
