using System.ComponentModel.DataAnnotations;

namespace Timepiece.Common.DTOs.AccountDTOs
{
    public class CreateAccountDto
    {
        public Guid role_id { get; set; }
        public string full_name { get; set; } = null!;
        public string email { get; set; } = null!;
        public string password_hash { get; set; } = null!;
        public string? phone_number { get; set; }
    }
}
