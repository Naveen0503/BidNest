using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BidNest_Library.Models;

public partial class ItemImage
{
    [Key]
    public int ImageId { get; set; }

    public int? ItemId { get; set; }

    public byte[]? ImageData { get; set; }

    public virtual Item? Item { get; set; }
}
