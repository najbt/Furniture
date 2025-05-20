using System;
using System.Collections.Generic;

namespace Furniture.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string BlogContent { get; set; } = null!;

    public string? BlogImgUrl { get; set; }

    public DateTime? BlogDate { get; set; }
}
