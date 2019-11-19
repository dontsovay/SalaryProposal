using FluentValidation;
using SalaryProposal.API.Models.Request;

namespace SalaryProposal.API.Models.Validation
{
    /// <summary></summary>
    /// <seealso cref="FluentValidation.AbstractValidator{SalaryProposal.API.Models.Request.ExchangeRefreshTokenRequest}" />
    public class ExchangeRefreshTokenRequestValidator : AbstractValidator<ExchangeRefreshTokenRequest>
    {
        /// <summary>Initializes a new instance of the <see cref="ExchangeRefreshTokenRequestValidator"/> class.</summary>
        public ExchangeRefreshTokenRequestValidator()
        {
            RuleFor(x => x.AccessToken).NotEmpty();
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}
