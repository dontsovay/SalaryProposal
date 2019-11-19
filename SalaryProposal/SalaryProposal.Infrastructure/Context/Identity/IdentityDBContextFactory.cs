using Microsoft.EntityFrameworkCore;
using SalaryProposal.Infrastructure.Shared;

namespace SalaryProposal.Infrastructure.Identity
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Shared.DesignTimeDbContextFactoryBase{SalaryProposal.Infrastructure.Identity.IdentityDBContext}" />
    public class IdentityDBContextFactory : DesignTimeDbContextFactoryBase<IdentityDBContext>
    {
        /// <summary>Creates the new instance.</summary>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        protected override IdentityDBContext CreateNewInstance(DbContextOptions<IdentityDBContext> options)
        {
            return new IdentityDBContext(options);
        }
    }
}