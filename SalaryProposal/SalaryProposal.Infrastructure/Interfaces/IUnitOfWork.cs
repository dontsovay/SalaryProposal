using System;

namespace SalaryProposal.Infrastructure.Interfaces
{
    /// <summary></summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork: IDisposable
    {
        /// <summary>Gets the regions.</summary>
        /// <value>The regions.</value>
        IRegionRepository Regions { get; }

        /// <summary>Gets the positions.</summary>
        /// <value>The positions.</value>
        IPositionRepository Positions { get; }

        /// <summary>Gets the calculation data.</summary>
        /// <value>The calculation data.</value>
        ICalculationRepository CalculationData { get; }

        /// <summary>Saves this instance.</summary>
        void Save();
    }
}
