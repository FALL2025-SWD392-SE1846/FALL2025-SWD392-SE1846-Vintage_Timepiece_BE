using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

public partial class appraisalrequest
{
    [Key]
    public Guid request_id { get; set; }

    public Guid seller_id { get; set; }

    [StringLength(100)]
    public string brand { get; set; } = null!;

    [StringLength(255)]
    public string product_name { get; set; } = null!;

    public string condition { get; set; } = null!;

    public string? condition_details { get; set; }

    public string? accessories { get; set; }

    [Precision(12, 2)]
    public decimal? desired_price { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime created_at { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? updated_at { get; set; }

    [InverseProperty("request")]
    public virtual appraisalreport? appraisalreport { get; set; }

    [InverseProperty("request")]
    public virtual conversation? conversation { get; set; }

    [InverseProperty("request")]
    public virtual product? product { get; set; }

    [InverseProperty("request")]
    public virtual ICollection<productmedium> productmedia { get; set; } = new List<productmedium>();

    [ForeignKey("seller_id")]
    [InverseProperty("appraisalrequests")]
    public virtual account seller { get; set; } = null!;
}
