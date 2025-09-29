using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

[Index("account_id", Name = "carts_account_id_key", IsUnique = true)]
public partial class cart
{
    [Key]
    public Guid cart_id { get; set; }

    public Guid account_id { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime created_at { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? updated_at { get; set; }

    [ForeignKey("account_id")]
    [InverseProperty("cart")]
    public virtual account account { get; set; } = null!;

    [InverseProperty("cart")]
    public virtual ICollection<cartitem> cartitems { get; set; } = new List<cartitem>();
}
