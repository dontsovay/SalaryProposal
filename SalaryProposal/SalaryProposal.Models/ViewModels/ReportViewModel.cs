using System;

namespace SalaryProposal.API.ViewModels
{
    public class ReportViewModel
    {
        ///// <summary>Gets or sets the last name.</summary>
        ///// <value>The last name.</value>
        //public string LastName { get; set; }

        ///// <summary>Gets or sets the first name.</summary>
        ///// <value>The first name.</value>
        //public string FirstName { get; set; }

        ///// <summary>Gets or sets the birth date.</summary>
        ///// <value>The birth date.</value>
        //public DateTime BirthDate { get; set; }
        
        //public decimal EmployeeNumber { get; set; }

        /// <summary>Gets or sets the function.</summary>
        /// <value>The function.</value>
        public string Function { get; set; }

        /// <summary>Gets or sets the experience.</summary>
        /// <value>The experience.</value>
        public decimal Experience { get; set; }

        /// <summary>Gets or sets the region fk.</summary>
        /// <value>The region fk.</value>
        public Guid RegionFk { get; set; }

        /// <summary>Gets or sets the region.</summary>
        /// <value>The region.</value>
        public string Region { get; set; }

        /// <summary>Gets or sets the minimum salary.</summary>
        /// <value>The minimum salary.</value>
        public decimal MinSalary { get; set; }

        /// <summary>Gets or sets the maximum salary.</summary>
        /// <value>The maximum salary.</value>
        public decimal MaxSalary { get; set; }
    }
}
