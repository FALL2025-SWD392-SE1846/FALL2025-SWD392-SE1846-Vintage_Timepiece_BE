using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

[Index("slug", Name = "blogposts_slug_key", IsUnique = true)]
public partial class blogpost
{
    [Key]
    public Guid post_id { get; set; }

    public Guid author_id { get; set; }

    [StringLength(255)]
    public string title { get; set; } = null!;

    [StringLength(255)]
    public string slug { get; set; } = null!;

    public string content { get; set; } = null!;

    [StringLength(255)]
    public string? featured_image_url { get; set; }

    [StringLength(20)]
    public string? status { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? published_at { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime created_at { get; set; }

    [ForeignKey("author_id")]
    [InverseProperty("blogposts")]
    public virtual account author { get; set; } = null!;
}
