using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

public partial class notification
{
    [Key]
    public Guid notification_id { get; set; }

    public Guid account_id { get; set; }

    [StringLength(255)]
    public string title { get; set; } = null!;

    public string message { get; set; } = null!;

    [StringLength(255)]
    public string? link_url { get; set; }

    public bool? is_read { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime created_at { get; set; }

    [ForeignKey("account_id")]
    [InverseProperty("notifications")]
    public virtual account account { get; set; } = null!;
}
