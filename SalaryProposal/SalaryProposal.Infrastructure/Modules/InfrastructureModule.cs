using Autofac;
using SalaryProposal.API.Services;
using SalaryProposal.API.Services.Interfaces;
using SalaryProposal.Infrastructure.Auth;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Infrastructure.Interfaces.Services;
using SalaryProposal.Infrastructure.Repositories;
using Module = Autofac.Module;

namespace SalaryProposal.Infrastructure.Modules
{
    /// <summary></summary>
    /// <seealso cref="Autofac.Module" />
    public class InfrastructureModule : Module
    {
        /// <summary>Override to add registrations to the container.</summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>Note that the ContainerBuilder parameter is unique to this module.</remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PositionRepository>().As<IPositionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RegionRepository>().As<IRegionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CalculationDataRepository>().As<ICalculationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<PositionsService>().As<IPositionsService>().InstancePerLifetimeScope();
            builder.RegisterType<RegionsService>().As<IRegionsService>().InstancePerLifetimeScope();
            builder.RegisterType<CalculationService>().As<ICalculationService>().InstancePerLifetimeScope();
            builder.RegisterType<UsersService>().As<IUsersService>().InstancePerLifetimeScope();
            builder.RegisterType<RolesService>().As<IRolesService>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance().FindConstructorsWith(new InternalConstructorFinder());
            builder.RegisterType<JwtTokenHandler>().As<IJwtTokenHandler>().SingleInstance().FindConstructorsWith(new InternalConstructorFinder());
            builder.RegisterType<TokenFactory>().As<ITokenFactory>().SingleInstance();
            builder.RegisterType<JwtTokenValidator>().As<IJwtTokenValidator>().SingleInstance().FindConstructorsWith(new InternalConstructorFinder());
        }
    }
}