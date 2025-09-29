using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

public partial class transaction
{
    [Key]
    public Guid transaction_id { get; set; }

    public Guid order_id { get; set; }

    [StringLength(255)]
    public string? gateway_transaction_id { get; set; }

    [StringLength(50)]
    public string payment_gateway { get; set; } = null!;

    [Precision(12, 2)]
    public decimal amount { get; set; }

    [StringLength(50)]
    public string status { get; set; } = null!;

    [Column(TypeName = "timestamp without time zone")]
    public DateTime created_at { get; set; }

    [ForeignKey("order_id")]
    [InverseProperty("transactions")]
    public virtual order order { get; set; } = null!;
}
