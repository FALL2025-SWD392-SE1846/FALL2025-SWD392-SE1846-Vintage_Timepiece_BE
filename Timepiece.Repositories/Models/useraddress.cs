using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

public partial class useraddress
{
    [Key]
    public Guid address_id { get; set; }

    public Guid account_id { get; set; }

    [StringLength(255)]
    public string full_name { get; set; } = null!;

    [StringLength(20)]
    public string phone_number { get; set; } = null!;

    public string address_line1 { get; set; } = null!;

    public string? address_line2 { get; set; }

    [StringLength(100)]
    public string city { get; set; } = null!;

    [StringLength(100)]
    public string district { get; set; } = null!;

    [StringLength(100)]
    public string ward { get; set; } = null!;

    public bool? is_default { get; set; }

    [ForeignKey("account_id")]
    [InverseProperty("useraddresses")]
    public virtual account account { get; set; } = null!;
}
