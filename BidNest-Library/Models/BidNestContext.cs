using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BidNest_Library.Models;

public partial class BidNestContext : DbContext
{
    public BidNestContext()
    {
    }

    public BidNestContext(DbContextOptions<BidNestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bid> Bids { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemImage> ItemImages { get; set; }

    public virtual DbSet<Shipping> Shippings { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=.;Database=BidNest;Trusted_Connection=True;TrustServerCertificate=True");
}
