using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

[Index("code", Name = "vouchers_code_key", IsUnique = true)]
public partial class voucher
{
    [Key]
    public Guid voucher_id { get; set; }

    [StringLength(50)]
    public string code { get; set; } = null!;

    [StringLength(20)]
    public string discount_type { get; set; } = null!;

    [Precision(12, 2)]
    public decimal discount_value { get; set; }

    [Precision(12, 2)]
    public decimal? max_discount_amount { get; set; }

    [Precision(12, 2)]
    public decimal? min_order_value { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? start_date { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? end_date { get; set; }

    public int? usage_limit { get; set; }

    public int? current_usage { get; set; }

    public bool? is_active { get; set; }

    [InverseProperty("voucher")]
    public virtual ICollection<ordervoucher> ordervouchers { get; set; } = new List<ordervoucher>();
}
