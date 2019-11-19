using System.Collections.Generic;

namespace SalaryProposal.Models.Models
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Models.Models.BaseModel" />
    public class Roles : BaseModel
    {
        /// <summary>Initializes a new instance of the <see cref="Roles"/> class.</summary>
        /// <param name="name">The name.</param>
        public Roles(string name)
        {
            Name = name;
        }
        
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>Gets or sets the users.</summary>
        /// <value>The users.</value>
        public virtual ICollection<Users> Users { get; set; }

        /// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return (obj as Roles)?.Name.Equals(Name) ?? false;
        }

        /// <summary>Returns a hash code for this instance.</summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return (string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode());
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
