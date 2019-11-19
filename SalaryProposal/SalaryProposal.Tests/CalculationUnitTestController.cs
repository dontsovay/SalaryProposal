using Microsoft.EntityFrameworkCore;
using SalaryProposal.API.Services;
using SalaryProposal.Infrastructure.Context;
using SalaryProposal.Infrastructure.Repositories;

namespace SalaryProposal.Tests
{
    /// <summary>Class provider for DBContext, service, repository</summary>
    public class CalculationUnitTestController
    {
        /// <summary>The repository</summary>
        public CalculationDataRepository Repository { get; }

        /// <summary>The service</summary>
        public CalculationService Service { get; }

        /// <summary>Gets the database context options.</summary>
        /// <value>The database context options.</value>
        public static DbContextOptions<DBContext> DbContextOptions { get; }

        /// <summary>The connection string</summary>
        public static string ConnectionString = "Data Source=.;Initial Catalog=SalaryProposal;Integrated Security=True";

        /// <summary>Initializes the <see cref="CalculationUnitTestController"/> class.</summary>
        static CalculationUnitTestController()
        {
            DbContextOptions = new DbContextOptionsBuilder<DBContext>()
                .UseSqlServer(ConnectionString)
                .Options;
        }

        /// <summary>Initializes a new instance of the <see cref="CalculationUnitTestController"/> class.</summary>
        public CalculationUnitTestController()
        {
            var context = new DBContext(DbContextOptions);
            Repository = new CalculationDataRepository(context);
            Service = new CalculationService(Repository);
        }
    }
}
