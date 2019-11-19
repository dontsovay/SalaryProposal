
namespace SalaryProposal.Infrastructure.Interfaces.Services
{
    /// <summary></summary>
    public interface ITokenFactory
    {
        /// <summary>Generates the token.</summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        string GenerateToken(int size = 32);
    }
}
