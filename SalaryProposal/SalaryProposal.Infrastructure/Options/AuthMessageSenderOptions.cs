namespace SalaryProposal.Infrastructure.Options
{
    /// <summary></summary>
    public class AuthMessageSenderOptions
    {
        /// <summary>Gets or sets the host.</summary>
        /// <value>The host.</value>
        public string Host { get; set; }

        /// <summary>Gets or sets the port.</summary>
        /// <value>The port.</value>
        public int Port { get; set; }

        /// <summary>Gets or sets the address.</summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>Gets or sets the password.</summary>
        /// <value>The password.</value>
        public string Password { get; set; }
    }
}