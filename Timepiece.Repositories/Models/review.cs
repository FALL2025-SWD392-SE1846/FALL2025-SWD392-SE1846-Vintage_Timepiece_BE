using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

[Index("product_id", "account_id", "order_id", Name = "reviews_product_id_account_id_order_id_key", IsUnique = true)]
public partial class review
{
    [Key]
    public Guid review_id { get; set; }

    public Guid product_id { get; set; }

    public Guid account_id { get; set; }

    public Guid order_id { get; set; }

    public int rating { get; set; }

    public string? comment { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime created_at { get; set; }

    [ForeignKey("account_id")]
    [InverseProperty("reviews")]
    public virtual account account { get; set; } = null!;

    [ForeignKey("order_id")]
    [InverseProperty("reviews")]
    public virtual order order { get; set; } = null!;

    [ForeignKey("product_id")]
    [InverseProperty("reviews")]
    public virtual product product { get; set; } = null!;
}
