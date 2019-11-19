using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Specifications
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Specifications.BaseSpecification{SalaryProposal.Models.Models.Users}" />
    public sealed class UserSpecification : BaseSpecification<Users>
    {
        /// <summary>Initializes a new instance of the <see cref="UserSpecification"/> class.</summary>
        /// <param name="identityId">The identity identifier.</param>
        public UserSpecification(string identityId) : base(u => u.IdentityId == identityId)
        {
            AddInclude(u => u.RefreshTokens);
            AddInclude(u => u.Role);
        }
    }
}
