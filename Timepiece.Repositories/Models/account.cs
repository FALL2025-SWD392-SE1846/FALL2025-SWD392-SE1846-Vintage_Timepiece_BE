using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timepiece.Repositories.Models;

[Index("email", Name = "accounts_email_key", IsUnique = true)]
[Index("phone_number", Name = "accounts_phone_number_key", IsUnique = true)]
public partial class account
{
    [Key]
    public Guid account_id { get; set; }

    [StringLength(255)]
    public string full_name { get; set; } = null!;

    [StringLength(255)]
    public string email { get; set; } = null!;

    [StringLength(255)]
    public string password_hash { get; set; } = null!;

    [StringLength(20)]
    public string? phone_number { get; set; }

    public Guid role_id { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime created_at { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? updated_at { get; set; }

    [InverseProperty("appraiser")]
    public virtual ICollection<appraisalreport> appraisalreports { get; set; } = new List<appraisalreport>();

    [InverseProperty("seller")]
    public virtual ICollection<appraisalrequest> appraisalrequests { get; set; } = new List<appraisalrequest>();

    [InverseProperty("author")]
    public virtual ICollection<blogpost> blogposts { get; set; } = new List<blogpost>();

    [InverseProperty("account")]
    public virtual cart? cart { get; set; }

    [InverseProperty("sender")]
    public virtual ICollection<message> messages { get; set; } = new List<message>();

    [InverseProperty("account")]
    public virtual ICollection<notification> notifications { get; set; } = new List<notification>();

    [InverseProperty("buyer")]
    public virtual ICollection<order> orders { get; set; } = new List<order>();

    [InverseProperty("account")]
    public virtual ICollection<review> reviews { get; set; } = new List<review>();

    [ForeignKey("role_id")]
    [InverseProperty("accounts")]
    public virtual role role { get; set; } = null!;

    [InverseProperty("account")]
    public virtual ICollection<useraddress> useraddresses { get; set; } = new List<useraddress>();
}
