using System;
using System.Threading.Tasks;
using SalaryProposal.API.Services.Interfaces;
using SalaryProposal.API.ViewModels;
using SalaryProposal.Infrastructure.Configurations;
using SalaryProposal.Infrastructure.Interfaces;

namespace SalaryProposal.API.Services
{
    /// <summary>Regions Service</summary>
    /// <seealso cref="SalaryProposal.API.Services.Interfaces.ICalculationService" />
    public class CalculationService : ICalculationService
    {
        /// <summary>The regions repository</summary>
        private readonly ICalculationRepository _calculationRepository;

        /// <summary>Initializes a new instance of the <see cref="CalculationService"/> class.</summary>
        /// <param name="calculationRepository">The positions repository.</param>
        public CalculationService(ICalculationRepository calculationRepository)
        {
            _calculationRepository = calculationRepository;
        }

        /// <summary>Calculates the specified calculation view model.</summary>
        /// <param name="calculationViewModel">The calculation view model.</param>
        /// <returns></returns>
        public async Task<ReportViewModel> Calculate(CalculationViewModel calculationViewModel)
        {
            if (calculationViewModel == null)
                throw new Exception("Calculation model cannot be null");
            if (calculationViewModel.Experience < 1 || calculationViewModel.Experience > 20)
                throw new Exception("Experience is not valid value: takes values ​​from 1 to 20");
            var data = await _calculationRepository.GetByPositionAndRegion(calculationViewModel.Function, calculationViewModel.Region);
            if (data == null)
                throw new Exception("Function or Region not found");

            var minSalary = (double)data.MinSalary;                                     // C3
            var maxSalary = (double)data.MaxSalary;                                     // C4
            var experience = (double)calculationViewModel.Experience;                   // B3

            var extra = data.Position.IsLead ? maxSalary * 0.1 : 0;                     // C5
            var surcharge = (maxSalary - minSalary - extra) * 0.05;                     // C6

            var from = minSalary + Math.Round(experience * 0.2, 1) * surcharge;
            var to = surcharge * experience + minSalary + extra;

            return new ReportViewModel()
            {
                MinSalary = (decimal)Math.Round(from, Calculation.DecimalPlaces),
                MaxSalary = (decimal)Math.Round(to, Calculation.DecimalPlaces)
            };
        }
    }
}
