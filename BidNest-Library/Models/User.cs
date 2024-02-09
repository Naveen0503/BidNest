using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BidNest_Library.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public string? Role { get; set; }

    public byte[]? ProfileImage { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
