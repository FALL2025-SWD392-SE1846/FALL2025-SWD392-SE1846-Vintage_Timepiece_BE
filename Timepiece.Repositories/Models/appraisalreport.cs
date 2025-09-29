using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

[Index("request_id", Name = "appraisalreports_request_id_key", IsUnique = true)]
public partial class appraisalreport
{
    [Key]
    public Guid report_id { get; set; }

    public Guid request_id { get; set; }

    public Guid appraiser_id { get; set; }

    [StringLength(100)]
    public string authenticity_result { get; set; } = null!;

    [StringLength(100)]
    public string? serial_number { get; set; }

    [StringLength(100)]
    public string? movement_type { get; set; }

    [StringLength(100)]
    public string? case_material { get; set; }

    [StringLength(100)]
    public string? strap_material { get; set; }

    [StringLength(100)]
    public string? dimensions { get; set; }

    public string detailed_assessment { get; set; } = null!;

    public string? market_value_analysis { get; set; }

    [Precision(12, 2)]
    public decimal purchase_price { get; set; }

    [Precision(12, 2)]
    public decimal listing_price { get; set; }

    [StringLength(255)]
    public string? report_pdf_url { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime created_at { get; set; }

    [ForeignKey("appraiser_id")]
    [InverseProperty("appraisalreports")]
    public virtual account appraiser { get; set; } = null!;

    [InverseProperty("report")]
    public virtual product? product { get; set; }

    [ForeignKey("request_id")]
    [InverseProperty("appraisalreport")]
    public virtual appraisalrequest request { get; set; } = null!;
}
