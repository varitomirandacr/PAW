﻿using System;
using System.Collections.Generic;

namespace PAW.Models;

public partial class CatalogTask
{
    public decimal Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal TaskId { get; set; }

    public decimal Status { get; set; }

    public DateTime ModifiedDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;
}
