using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

[PrimaryKey("order_id", "voucher_id")]
public partial class ordervoucher
{
    [Key]
    public Guid order_id { get; set; }

    [Key]
    public Guid voucher_id { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? applied_at { get; set; }

    [ForeignKey("order_id")]
    [InverseProperty("ordervouchers")]
    public virtual order order { get; set; } = null!;

    [ForeignKey("voucher_id")]
    [InverseProperty("ordervouchers")]
    public virtual voucher voucher { get; set; } = null!;
}
