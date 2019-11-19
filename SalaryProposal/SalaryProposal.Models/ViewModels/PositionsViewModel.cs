namespace SalaryProposal.API.ViewModels
{
    public class PositionsViewModel: BaseViewModel
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is lead.</summary>
        /// <value>
        ///   <c>true</c> if this instance is lead; otherwise, <c>false</c>.</value>
        public bool? IsLead { get; set; }
    }
}
