using System;

namespace SalaryProposal.Models.Models
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Models.Models.BaseModel" />
    public class Logs: BaseModel
    {
        /// <summary>Gets or sets the URL.</summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>Gets or sets the user.</summary>
        /// <value>The user.</value>
        public string User { get; set; }

        /// <summary>Gets or sets the date.</summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }
    }
}
