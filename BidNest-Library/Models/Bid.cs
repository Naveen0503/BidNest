using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BidNest_Library.Models;

public partial class Bid
{
    [Key]
    public int BidId { get; set; }

    public int? BidderId { get; set; }

    public int? ItemId { get; set; }

    public decimal? BidAmount { get; set; }

    public DateTime? BidTime { get; set; }

    public virtual User? Bidder { get; set; }

    public virtual Item? Item { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
