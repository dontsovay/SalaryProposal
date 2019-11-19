using System;

namespace SalaryProposal.Models.Models
{
    /// <summary></summary>
    public class BaseModel
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the insert date.</summary>
        /// <value>The insert date.</value>
        public DateTime InsertDate { get; set; }

        /// <summary>Gets or sets the update date.</summary>
        /// <value>The update date.</value>
        public DateTime UpdateDate { get; set; }

        /// <summary>Gets or sets the insert user.</summary>
        /// <value>The insert user.</value>
        public string InsertUser { get; set; }

        /// <summary>Gets or sets the update user.</summary>
        /// <value>The update user.</value>
        public string UpdateUser { get; set; }
    }
}
