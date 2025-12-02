using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Groovarr.Api.Data
{
    public class AppUser : Microsoft.AspNetCore.Identity.IdentityUser { }

    public class AuthDbContext : IdentityDbContext<AppUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }
    }
}
