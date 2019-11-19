using Autofac;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SalaryProposal.Infrastructure.Interfaces.UseCases;
using SalaryProposal.Infrastructure.UseCases;

namespace SalaryProposal.Infrastructure.Modules
{
    /// <summary></summary>
    /// <seealso cref="Autofac.Module" />
    public class CoreModule : Module
    {
        /// <summary>Override to add registrations to the container.</summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>Note that the ContainerBuilder parameter is unique to this module.</remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterUserUseCase>().As<IRegisterUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<ForgotPasswordUseCase>().As<IForgotPasswordUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<ResetPasswordUseCase>().As<IResetPasswordUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<ExchangeRefreshTokenUseCase>().As<IExchangeRefreshTokenUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<AuthMessageSender>().As<IEmailSender>().InstancePerLifetimeScope();
        }
    }
}