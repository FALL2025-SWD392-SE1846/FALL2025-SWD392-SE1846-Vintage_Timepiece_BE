using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

[Index("report_id", Name = "products_report_id_key", IsUnique = true)]
[Index("request_id", Name = "products_request_id_key", IsUnique = true)]
[Index("sku", Name = "products_sku_key", IsUnique = true)]
public partial class product
{
    [Key]
    public Guid product_id { get; set; }

    public Guid request_id { get; set; }

    public Guid report_id { get; set; }

    [StringLength(100)]
    public string sku { get; set; } = null!;

    [StringLength(100)]
    public string brand { get; set; } = null!;

    [StringLength(255)]
    public string product_name { get; set; } = null!;

    public string description { get; set; } = null!;

    [Precision(12, 2)]
    public decimal listing_price { get; set; }

    [StringLength(100)]
    public string? movement_type { get; set; }

    [StringLength(100)]
    public string? case_material { get; set; }

    [StringLength(100)]
    public string? strap_material { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime listed_at { get; set; }

    [InverseProperty("product")]
    public virtual cartitem? cartitem { get; set; }

    [InverseProperty("product")]
    public virtual order? order { get; set; }

    [ForeignKey("report_id")]
    [InverseProperty("product")]
    public virtual appraisalreport report { get; set; } = null!;

    [ForeignKey("request_id")]
    [InverseProperty("product")]
    public virtual appraisalrequest request { get; set; } = null!;

    [InverseProperty("product")]
    public virtual ICollection<review> reviews { get; set; } = new List<review>();
}
