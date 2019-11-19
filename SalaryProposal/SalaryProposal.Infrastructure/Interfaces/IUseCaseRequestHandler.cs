using System.Threading.Tasks;

namespace SalaryProposal.Infrastructure.Interfaces
{
    /// <summary></summary>
    /// <typeparam name="TUseCaseRequest">The type of the use case request.</typeparam>
    /// <typeparam name="TUseCaseResponse">The type of the use case response.</typeparam>
    public interface IUseCaseRequestHandler<in TUseCaseRequest, out TUseCaseResponse> where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
    {
        /// <summary>Handles the specified message.</summary>
        /// <param name="message">The message.</param>
        /// <param name="outputPort">The output port.</param>
        /// <returns></returns>
        Task<bool> Handle(TUseCaseRequest message, IOutputPort<TUseCaseResponse> outputPort);
    }
}
