using System;

namespace SalaryProposal.API.ViewModels
{
    public class CalculationViewModel
    {
        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>Gets or sets the birth date.</summary>
        /// <value>The birth date.</value>
        public DateTime BirthDate { get; set; }

        /// <summary>Gets or sets the employee number.</summary>
        /// <value>The employee number.</value>
        public decimal EmployeeNumber { get; set; }

        /// <summary>Gets or sets the function.</summary>
        /// <value>The function.</value>
        public string Function { get; set; }

        /// <summary>Gets or sets the experience.</summary>
        /// <value>The experience.</value>
        public decimal Experience { get; set; }

        /// <summary>Gets or sets the region.</summary>
        /// <value>The region.</value>
        public string Region { get; set; }
    }
}
