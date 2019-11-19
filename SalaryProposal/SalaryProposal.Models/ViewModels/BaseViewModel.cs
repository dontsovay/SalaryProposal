using System;

namespace SalaryProposal.API.ViewModels
{
    public class BaseViewModel
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the insert date.</summary>
        /// <value>The insert date.</value>
        public DateTime? InsertDate { get; set; }

        /// <summary>Gets or sets the modify date.</summary>
        /// <value>The modify date.</value>
        public DateTime? ModifyDate { get; set; }

        /// <summary>Gets or sets the insert user.</summary>
        /// <value>The insert user.</value>
        public string InsertUser { get; set; }

        /// <summary>Gets or sets the modify user.</summary>
        /// <value>The modify user.</value>
        public string ModifyUser { get; set; }
    }
}
