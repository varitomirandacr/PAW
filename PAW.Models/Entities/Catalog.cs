using System;
using System.Collections.Generic;

namespace PAW.Models;

public partial class Catalog
{
    public int Identifier { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Sku { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public decimal? Rating { get; set; }
}
