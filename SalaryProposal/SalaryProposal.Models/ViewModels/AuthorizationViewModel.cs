namespace SalaryProposal.API.ViewModels
{
    public class AuthorizationViewModel
    {
        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>Gets or sets the password.</summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>Gets or sets a value indicating whether [remember me].</summary>
        /// <value>
        ///   <c>true</c> if [remember me]; otherwise, <c>false</c>.</value>
        public bool RememberMe { get; set; }

    }
}
