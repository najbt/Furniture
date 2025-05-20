using System;
using System.Collections.Generic;

namespace Furniture.Models;

public partial class Furniture
{
    public int FurnitureId { get; set; }

    public string FurnitureName { get; set; } = null!;

    public decimal FurniturePrice { get; set; }

    public string? FurnitureImgUrl { get; set; }

    public int CategoryId { get; set; }

    public virtual FurnitureCategory Category { get; set; } = null!;
}
