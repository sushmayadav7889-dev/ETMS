using Microsoft.AspNetCore.Identity;

namespace ETMS.Infrastructure.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}

