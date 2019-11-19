using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalaryProposal.Infrastructure.Shared;
using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Context
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Shared.DesignTimeDbContextFactoryBase{SalaryProposal.Infrastructure.Context.DBContext}" />
    public class DBContextFactory : DesignTimeDbContextFactoryBase<DBContext>
    {
        /// <summary>Creates the new instance.</summary>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        protected override DBContext CreateNewInstance(DbContextOptions<DBContext> options)
        {
            return new DBContext(options);
        }
    }
}
