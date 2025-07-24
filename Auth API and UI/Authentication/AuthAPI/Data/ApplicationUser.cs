using Microsoft.AspNetCore.Identity;

namespace AuthAPI.Data
{
    public class ApplicationUser : IdentityUser
    {
        //public string Id { get; set; } = Guid.NewGuid().ToString();
        //public string UserName { get; set; }
        //public string NormalizedUserName { get; set; }
        //public string Email { get; set; }
        //public string NormalizedEmail { get; set; }
        //public bool EmailConfirmed { get; set; }
        //public string PasswordHash { get; set; }
        //public string SecurityStamp { get; set; }
        //public string ConcurrencyStamp { get; set; }
        //public DateTimeOffset? LockoutEnd { get; set; }
        //public bool LockoutEnabled { get; set; }
        //public int AccessFailedCount { get; set; }

        // Additional properties can be added here
        public string Name { get; set; }
    }
    
}
