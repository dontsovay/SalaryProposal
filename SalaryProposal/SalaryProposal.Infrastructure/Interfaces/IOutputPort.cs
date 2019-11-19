

namespace SalaryProposal.Infrastructure.Interfaces
{
    /// <summary></summary>
    /// <typeparam name="TUseCaseResponse">The type of the use case response.</typeparam>
    public interface IOutputPort<in TUseCaseResponse>
    {
        /// <summary>Handles the specified response.</summary>
        /// <param name="response">The response.</param>
        void Handle(TUseCaseResponse response);
    }
}
