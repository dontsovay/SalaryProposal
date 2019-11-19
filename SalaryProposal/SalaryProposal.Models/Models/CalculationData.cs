using System;

namespace SalaryProposal.Models.Models
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Models.Models.BaseModel" />
    public class CalculationData: BaseModel
    {
        /// <summary>Gets or sets the position identifier.</summary>
        /// <value>The position identifier.</value>
        public Guid PositionId { get; set; }

        /// <summary>Gets or sets the position.</summary>
        /// <value>The position.</value>
        public Positions Position { get; set; }

        /// <summary>Gets or sets the region identifier.</summary>
        /// <value>The region identifier.</value>
        public Guid RegionId { get; set; }

        /// <summary>Gets or sets the region.</summary>
        /// <value>The region.</value>
        public Regions Region { get; set; }

        /// <summary>Gets or sets the minimum salary.</summary>
        /// <value>The minimum salary.</value>
        public decimal MinSalary { get; set; }

        /// <summary>Gets or sets the maximum salary.</summary>
        /// <value>The maximum salary.</value>
        public decimal MaxSalary { get; set; }

        /// <summary>Gets or sets the experience.</summary>
        /// <value>The experience.</value>
        public decimal Experience { get; set; }
    }
}
