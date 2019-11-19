 

namespace SalaryProposal.Infrastructure.Dto
{
    /// <summary></summary>
    public sealed class Error
    {
        /// <summary>Gets the code.</summary>
        /// <value>The code.</value>
        public string Code { get; }

        /// <summary>Gets the description.</summary>
        /// <value>The description.</value>
        public string Description { get; }

        /// <summary>Initializes a new instance of the <see cref="Error"/> class.</summary>
        /// <param name="code">The code.</param>
        /// <param name="description">The description.</param>
        public Error(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
