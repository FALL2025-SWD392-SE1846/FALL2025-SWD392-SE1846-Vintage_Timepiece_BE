using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

[Index("order_code", Name = "orders_order_code_key", IsUnique = true)]
[Index("product_id", Name = "orders_product_id_key", IsUnique = true)]
public partial class order
{
    [Key]
    public Guid order_id { get; set; }

    [StringLength(50)]
    public string order_code { get; set; } = null!;

    public Guid buyer_id { get; set; }

    public Guid product_id { get; set; }

    [Precision(12, 2)]
    public decimal subtotal { get; set; }

    [Precision(10, 2)]
    public decimal? shipping_fee { get; set; }

    [Precision(12, 2)]
    public decimal? discount_amount { get; set; }

    [Precision(12, 2)]
    public decimal total_amount { get; set; }

    public string shipping_address { get; set; } = null!;

    [StringLength(100)]
    public string? shipping_method { get; set; }

    [StringLength(100)]
    public string? shipping_partner { get; set; }

    [StringLength(100)]
    public string? tracking_code { get; set; }

    [StringLength(50)]
    public string payment_method { get; set; } = null!;

    [Column(TypeName = "timestamp without time zone")]
    public DateTime created_at { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? updated_at { get; set; }

    [ForeignKey("buyer_id")]
    [InverseProperty("orders")]
    public virtual account buyer { get; set; } = null!;

    [InverseProperty("order")]
    public virtual ICollection<ordervoucher> ordervouchers { get; set; } = new List<ordervoucher>();

    [ForeignKey("product_id")]
    [InverseProperty("order")]
    public virtual product product { get; set; } = null!;

    [InverseProperty("order")]
    public virtual ICollection<review> reviews { get; set; } = new List<review>();

    [InverseProperty("order")]
    public virtual ICollection<transaction> transactions { get; set; } = new List<transaction>();
}
