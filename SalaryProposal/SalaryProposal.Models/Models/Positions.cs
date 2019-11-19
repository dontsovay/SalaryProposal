using System.Collections.Generic;

namespace SalaryProposal.Models.Models
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Models.Models.BaseModel"/>
    public class Positions : BaseModel
    {
        /// <summary>Initializes a new instance of the <see cref="Positions"/> class.</summary>
        /// <param name="name">The name.</param>
        public Positions(string name)
        {
            Name = name;
        }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>Gets or sets a value indicating whether this instance is lead.</summary>
        /// <value>
        ///   <c>true</c> if this instance is lead; otherwise, <c>false</c>.</value>
        public bool IsLead { get; set; }

        /// <summary>Gets or sets the calculation datas.</summary>
        /// <value>The calculation datas.</value>
        public virtual ICollection<CalculationData> CalculationDatas { get; set; }

        /// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return (obj as Positions)?.Name.Equals(Name) ?? false;
        }

        /// <summary>Returns a hash code for this instance.</summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return (string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode());
        }
    }
}
