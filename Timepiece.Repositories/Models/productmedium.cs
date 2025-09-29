using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

public partial class productmedium
{
    [Key]
    public Guid media_id { get; set; }

    public Guid request_id { get; set; }

    [StringLength(255)]
    public string media_url { get; set; } = null!;

    public int? display_order { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime uploaded_at { get; set; }

    [ForeignKey("request_id")]
    [InverseProperty("productmedia")]
    public virtual appraisalrequest request { get; set; } = null!;
}
