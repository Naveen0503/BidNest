using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BidNest_Library.Models;

public partial class Item
{
    [Key]
    public int ItemId { get; set; }

    public int? SellerId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? InitialAmount { get; set; }

    public decimal? ClosingAmount { get; set; }

    public decimal? CurrentBidAmount { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual ICollection<ItemImage> ItemImages { get; set; } = new List<ItemImage>();

    public virtual User? Seller { get; set; }

    public virtual ICollection<Shipping> Shippings { get; set; } = new List<Shipping>();
}
