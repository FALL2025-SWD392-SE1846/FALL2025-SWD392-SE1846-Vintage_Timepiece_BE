using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

public partial class role
{
    [Key]
    public Guid role_id { get; set; }

    [InverseProperty("role")]
    public virtual ICollection<account> accounts { get; set; } = new List<account>();
}
