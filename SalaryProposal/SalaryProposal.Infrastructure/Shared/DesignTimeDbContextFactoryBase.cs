using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SalaryProposal.Infrastructure.Shared
{
    /// <summary></summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory{TContext}" />
    public abstract class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        /// <summary>Creates a new instance of a derived context.</summary>
        /// <param name="args">Arguments provided by the design-time service.</param>
        /// <returns>An instance of <span class="typeparameter">TContext</span>.</returns>
        public TContext CreateDbContext(string[] args)
        {
            return Create(Directory.GetCurrentDirectory(), Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
        }

        /// <summary>Creates the new instance.</summary>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        /// <summary>Creates this instance.</summary>
        /// <returns></returns>
        public TContext Create()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var basePath = AppContext.BaseDirectory;
            return Create(basePath, environmentName);
        }

        /// <summary>Creates the specified base path.</summary>
        /// <param name="basePath">The base path.</param>
        /// <param name="environmentName">Name of the environment.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Could not find a connection string named 'Default'.</exception>
        private TContext Create(string basePath, string environmentName)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            var connstr = config.GetConnectionString("Default");

            if (string.IsNullOrWhiteSpace(connstr))
            {
                throw new InvalidOperationException(
                    "Could not find a connection string named 'Default'.");
            }
            return Create(connstr);
        }

        /// <summary>Creates the specified connection string.</summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">connectionString</exception>
        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(
             $"{nameof(connectionString)} is null or empty.",
             nameof(connectionString));

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            Console.WriteLine("DesignTimeDbContextFactory.Create(string): Connection string: {0}", connectionString);

            optionsBuilder.UseSqlServer(connectionString);

            var options = optionsBuilder.Options;
            return CreateNewInstance(options);
        }
    }
}


