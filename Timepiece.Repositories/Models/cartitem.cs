using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

[Index("cart_id", "product_id", Name = "cartitems_cart_id_product_id_key", IsUnique = true)]
[Index("product_id", Name = "cartitems_product_id_key", IsUnique = true)]
public partial class cartitem
{
    [Key]
    public Guid cart_item_id { get; set; }

    public Guid cart_id { get; set; }

    public Guid product_id { get; set; }

    public int quantity { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime added_at { get; set; }

    [ForeignKey("cart_id")]
    [InverseProperty("cartitems")]
    public virtual cart cart { get; set; } = null!;

    [ForeignKey("product_id")]
    [InverseProperty("cartitem")]
    public virtual product product { get; set; } = null!;
}
