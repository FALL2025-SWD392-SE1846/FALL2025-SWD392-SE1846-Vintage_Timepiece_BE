using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

public partial class message
{
    [Key]
    public Guid message_id { get; set; }

    public Guid conversation_id { get; set; }

    public Guid sender_id { get; set; }

    public string content { get; set; } = null!;

    [Column(TypeName = "timestamp without time zone")]
    public DateTime sent_at { get; set; }

    public bool? is_read { get; set; }

    [ForeignKey("conversation_id")]
    [InverseProperty("messages")]
    public virtual conversation conversation { get; set; } = null!;

    [ForeignKey("sender_id")]
    [InverseProperty("messages")]
    public virtual account sender { get; set; } = null!;
}
