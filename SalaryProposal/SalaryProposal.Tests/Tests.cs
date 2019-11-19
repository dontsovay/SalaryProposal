using Microsoft.AspNetCore.Mvc;
using Xunit;
using CalculationController = SalaryProposal.API.Controllers.CalculationController;
using FluentAssertions;
using SalaryProposal.API.ViewModels;

namespace SalaryProposal.Tests
{
    /// <summary>Class for unit tests</summary>
    public class TheoryTests
    {
        /// <summary>Calculations the theory cases.</summary>
        /// <typeparam name="T">Expected result type</typeparam>
        /// <param name="returnType">Expected return type variable.</param>
        /// <param name="inputModel">The input model.</param>
        /// <param name="resultMinSalary">Expected result minimum salary.</param>
        /// <param name="resultMaxSalary">Expected result maximum salary.</param>
        [Theory]
        [MemberData(nameof(TestDataProvider.TestCases), MemberType = typeof(TestDataProvider))]
        public void CalculationTheoryCases<T>(T returnType, CalculationViewModel inputModel, decimal resultMinSalary = 0, decimal resultMaxSalary = 0)
        {
            ////Arrange
            //var testController = new CalculationUnitTestController();
            //var controller = new CalculationController(testController.Service);

            ////Act
            //var data = controller.Calculate(inputModel);

            ////Assert
            //Assert.NotNull(data.Result);
            //Assert.True(data.Result is ObjectResult);
            //var result = (ObjectResult)data.Result;
            //if (typeof(T) != typeof(OkObjectResult))
            //    return;
            //Assert.IsType<ReportViewModel>(result);
            //var viewModel = result.As<ReportViewModel>();
            //Assert.Equal(viewModel.MinSalary, resultMinSalary);
            //Assert.Equal(viewModel.MaxSalary, resultMaxSalary);
        }
    }
}
