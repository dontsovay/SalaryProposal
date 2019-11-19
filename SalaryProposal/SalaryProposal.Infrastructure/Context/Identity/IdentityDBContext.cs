using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SalaryProposal.Infrastructure.Identity
{
    /// <summary></summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDBContext{SalaryProposal.Infrastructure.Identity.AppUser}" />
    public class IdentityDBContext : IdentityDbContext<AppUser>
    {
        /// <summary>Initializes a new instance of the <see cref="IdentityDBContext"/> class.</summary>
        /// <param name="options">The options.</param>
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options) { }
    }
}
