using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BidNest_Library.Models;

public partial class Transaction
{
    [Key]
    public int TransactionId { get; set; }

    public int? BidId { get; set; }

    public int? WinningBidderId { get; set; }

    public decimal? WinningAmount { get; set; }

    public DateTime? TransactionTime { get; set; }

    public virtual Bid? Bid { get; set; }

    public virtual User? WinningBidder { get; set; }
}
