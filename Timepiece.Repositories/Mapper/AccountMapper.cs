using System.Runtime.CompilerServices;
using Timepiece.Common.DTOs.AccountDTOs;
using Timepiece.Repositories.Models;

namespace Timepiece.Repositories.Mapper
{
    public static class AccountMapper
    {
        public static GetAccountDto ToView(this account account)
        {
            if (account == null) throw new ArgumentNullException(nameof(account), "No account exist");
            return new GetAccountDto
            {
                account_id = account.account_id,
                role_id = account.role_id,
                full_name = account.full_name,
                email = account.email,
                password_hash = account.password_hash,
                phone_number = account.phone_number,
                created_at = account.created_at,
                updated_at = account.updated_at
            };
        }

    public static account ToCreate(this CreateAccountDto createAccountDto)
        {
            if (createAccountDto == null) 
                throw new ArgumentNullException(nameof(createAccountDto), "CreateAccountDto cannot be null");

            if (string.IsNullOrEmpty(createAccountDto.full_name) ||
                string.IsNullOrEmpty(createAccountDto.email) ||
                string.IsNullOrEmpty(createAccountDto.phone_number) ||
                string.IsNullOrEmpty(createAccountDto.password_hash))

                throw new ArgumentException("Full name cannot be null or empty", nameof(createAccountDto));

            var account = new account
            {
                role_id = createAccountDto.role_id,
                full_name = createAccountDto.full_name,
                email = createAccountDto.email,
                password_hash = createAccountDto.password_hash,
                phone_number = createAccountDto.phone_number,
            };

            return account;
        }
        
        public static void ToUpdate(this UpdateAccountDto dto, account account)
        {
            if(!string.IsNullOrEmpty(dto.full_name))
                account.full_name = dto.full_name;

            if(dto.role_id != Guid.Empty)
                account.role_id = dto.role_id;

            if(!string.IsNullOrEmpty(dto.email))
                account.email = dto.email;
            if(!string.IsNullOrEmpty(dto.password_hash))
                account.password_hash = dto.password_hash;
            if(!string.IsNullOrEmpty(dto.phone_number))
                account.phone_number = dto.phone_number;
        }
    }

    
}
