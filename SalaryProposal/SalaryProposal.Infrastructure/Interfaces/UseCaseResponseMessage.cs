namespace SalaryProposal.Infrastructure.Interfaces
{
    public abstract class UseCaseResponseMessage
    {
        /// <summary>Gets a value indicating whether this <see cref="UseCaseResponseMessage"/> is success.</summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; }

        /// <summary>Gets the message.</summary>
        /// <value>The message.</value>
        public string Message { get; }

        /// <summary>Initializes a new instance of the <see cref="UseCaseResponseMessage"/> class.</summary>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="message">The message.</param>
        protected UseCaseResponseMessage(bool success = false, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}
