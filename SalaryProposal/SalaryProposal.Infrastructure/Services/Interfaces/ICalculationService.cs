using System.Threading.Tasks;
using SalaryProposal.API.ViewModels;

namespace SalaryProposal.API.Services.Interfaces
{
    /// <summary>Interface for Calculation Service</summary>
    public interface ICalculationService
    {
        /// <summary>Calculates the specified calculation view model.</summary>
        /// <param name="calculationViewModel">The calculation view model.</param>
        /// <returns></returns>
        Task<ReportViewModel> Calculate(CalculationViewModel calculationViewModel);
    }
}
