using System;
using System.Collections.Generic;

namespace Furniture.Models;

public partial class FurnitureCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Furniture> Furnitures { get; set; } = new List<Furniture>();
}
