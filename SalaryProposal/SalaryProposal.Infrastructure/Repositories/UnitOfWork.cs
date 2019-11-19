using System;
using SalaryProposal.Infrastructure.Context;
using SalaryProposal.Infrastructure.Interfaces;

namespace SalaryProposal.Infrastructure.Repositories
{
    /// <summary></summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>The database context</summary>
        private readonly DBContext _context;

        /// <summary>The position repository</summary>
        private PositionRepository positionRepository;

        /// <summary>The region repository</summary>
        private RegionRepository regionRepository;

        /// <summary>The calculation data repository</summary>
        private CalculationDataRepository calculationDataRepository;

        /// <summary>Initializes a new instance of the <see cref="UnitOfWork"/> class.</summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(DBContext context)
        {
            _context = context;
        }

        /// <summary>Gets the regions.</summary>
        /// <value>The regions.</value>
        public IRegionRepository Regions
        {
            get
            {
                if (regionRepository == null)
                    regionRepository = new RegionRepository(_context);
                return regionRepository;
            }
        }

        /// <summary>Gets the positions.</summary>
        /// <value>The positions.</value>
        public IPositionRepository Positions
        {
            get
            {
                if (positionRepository == null)
                    positionRepository = new PositionRepository(_context);
                return positionRepository;
            }
        }

        /// <summary>Gets the calculation data.</summary>
        /// <value>The calculation data.</value>
        public ICalculationRepository CalculationData
        {
            get
            {
                if (calculationDataRepository == null)
                    calculationDataRepository = new CalculationDataRepository(_context);
                return calculationDataRepository;
            }
        }

        /// <summary>Saves this instance.</summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>The disposed</summary>
        private bool disposed = false;

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing">
        ///   <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
