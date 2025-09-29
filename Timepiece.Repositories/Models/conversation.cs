using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

[Index("request_id", Name = "conversations_request_id_key", IsUnique = true)]
public partial class conversation
{
    [Key]
    public Guid conversation_id { get; set; }

    public Guid request_id { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime created_at { get; set; }

    [InverseProperty("conversation")]
    public virtual ICollection<message> messages { get; set; } = new List<message>();

    [ForeignKey("request_id")]
    [InverseProperty("conversation")]
    public virtual appraisalrequest request { get; set; } = null!;
}
