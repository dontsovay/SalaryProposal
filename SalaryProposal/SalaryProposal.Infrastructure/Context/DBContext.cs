using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Context
{
    /// <summary></summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class DBContext : DbContext
    {
        /// <summary>Gets or sets the roles.</summary>
        /// <value>The roles.</value>
        public DbSet<Roles> Roles { get; set; }

        /// <summary>Gets or sets the refresh tokens.</summary>
        /// <value>The refresh tokens.</value>
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        /// <summary>Gets or sets the users.</summary>
        /// <value>The users.</value>
        public DbSet<Users> Users { get; set; }

        /// <summary>Gets or sets the calculation datas.</summary>
        /// <value>The calculation datas.</value>
        public DbSet<CalculationData> CalculationDatas { get; set; }

        /// <summary>Gets or sets the positions.</summary>
        /// <value>The positions.</value>
        public DbSet<Positions> Positions { get; set; }

        /// <summary>Gets or sets the regions.</summary>
        /// <value>The regions.</value>
        public DbSet<Regions> Regions { get; set; }

        /// <summary>Gets or sets the logs.</summary>
        /// <value>The logs.</value>
        public DbSet<Logs> Logs { get; set; }

        /// <summary>Initializes a new instance of the <see cref="DBContext"/> class.</summary>
        /// <param name="options">The options.</param>
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1"/> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">
        /// The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.
        /// </param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)"/>)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new CalculationDataConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new LogConfiguration());
        }

        /// <summary>Saves all changes made in this context to the database.</summary>
        /// <returns>The number of state entries written to the database.</returns>
        /// <remarks>
        /// This method will automatically call <see cref="M:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges"/> to discover any
        /// changes to entity instances before saving to the underlying database. This can be disabled via
        /// <see cref="P:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled"/>.
        /// </remarks>
        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        /// <summary>Saves the changes asynchronous.</summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }

        /// <summary>Adds the auit information.</summary>
        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseModel)entry.Entity).InsertDate = DateTime.UtcNow;
                }
                ((BaseModel)entry.Entity).UpdateDate = DateTime.UtcNow;
            }
        }
    }

    /// <summary></summary>
    /// <seealso cref="Regions" />
    public class RegionConfiguration : IEntityTypeConfiguration<Regions>
    {
        /// <summary>Configures the entity of type <span class="typeparameter">TEntity</span>.</summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Regions> builder)
        {
            builder
                .ToTable("Regions", schema: "dbo")
                .HasKey(p => p.Id);
            builder
                .Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder
                .HasMany(c => c.CalculationDatas)
                .WithOne(o => o.Region)
                .HasForeignKey(p => p.RegionId);
        }
    }

    /// <summary></summary>
    /// <seealso cref="Positions" />
    public class PositionConfiguration : IEntityTypeConfiguration<Positions>
    {
        /// <summary>Configures the entity of type <span class="typeparameter">TEntity</span>.</summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Positions> builder)
        {
            builder
                .ToTable("Positions", schema: "dbo")
                .HasKey(p => p.Id);
             builder
                .Property(p => p.Name).IsRequired().HasMaxLength(50);

            builder
                .HasMany(c => c.CalculationDatas)
                .WithOne(o => o.Position)
                .HasForeignKey(p => p.PositionId);

        }
    }

    /// <summary></summary>
    /// <seealso cref="CalculationData" />
    public class CalculationDataConfiguration : IEntityTypeConfiguration<CalculationData>
    {
        /// <summary>Configures the entity of type <span class="typeparameter">TEntity</span>.</summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<CalculationData> builder)
        {
            builder
                .ToTable("CalculationData", schema: "dbo")
                .HasKey(p => p.Id);
            builder
                .Property(p => p.MinSalary).IsRequired();
            builder
                .Property(p => p.MaxSalary).IsRequired();
            builder
                .Property(p => p.PositionId).IsRequired();
            builder
                .Property(p => p.RegionId).IsRequired();
        }
    }

    /// <summary></summary>
    /// <seealso cref="Users" />
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        /// <summary>Configures the entity of type <span class="typeparameter">TEntity</span>.</summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder
                .ToTable("Users", schema: "dbo")
                .HasKey(p => p.Id);
            builder
                .Property(p => p.FirstName).IsRequired();
            builder
                .Property(p => p.LastName).IsRequired();
            builder
                .Property(p => p.RoleId).IsRequired();
            builder
                .Property(p => p.IsActive).IsRequired();

            var navigation = builder.Metadata.FindNavigation(nameof(Models.Models.Users.RefreshTokens));
            //EF access the RefreshTokens collection property through its backing field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Ignore(b => b.Email);
            builder.Ignore(b => b.PasswordHash);
        }
    }

    /// <summary></summary>
    /// <seealso cref="Roles" />
    public class RoleConfiguration : IEntityTypeConfiguration<Roles>
    {
        /// <summary>Configures the entity of type <span class="typeparameter">TEntity</span>.</summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder
                .ToTable("Roles", schema: "dbo")
                .HasKey(p => p.Id);
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(15);
            builder
                .HasMany(c => c.Users)
                .WithOne(o => o.Role)
                .HasForeignKey(p => p.RoleId);
            builder
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
    
    /// <summary></summary>
    /// <seealso cref="Logs" />
    public class LogConfiguration : IEntityTypeConfiguration<Logs>
    {
        /// <summary>Configures the entity of type <span class="typeparameter">TEntity</span>.</summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Logs> builder)
        {
            builder
                .ToTable("Logs", schema: "dbo")
                .HasKey(p => p.Id);
            builder
                .Property(p => p.Url).IsRequired();
            builder
                .Property(p => p.Date).IsRequired();
        }
    }
}
