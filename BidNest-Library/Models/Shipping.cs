using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BidNest_Library.Models;

public partial class Shipping
{
    [Key]
    public int ShippingId { get; set; }

    public int? ItemId { get; set; }

    public string? ShippingAddress { get; set; }

    public string? ShippingStatus { get; set; }

    public string? TrackingNumber { get; set; }

    public virtual Item? Item { get; set; }
}
