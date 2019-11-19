using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SalaryProposal.API.ViewModels;

namespace SalaryProposal.Tests
{
    /// <summary>Cases for testing</summary>
    public static class TestDataProvider
    {
        /// <summary>Tests the cases.</summary>
        /// <returns></returns>
        public static IEnumerable<object[]> TestCases()
        {
            yield return new object[]
            {
                typeof(BadRequestObjectResult),
                new CalculationViewModel
                {
                    Experience = 1,
                    Region = "Denver",
                    Function = "CTO1"
                }
            };

            yield return new object[]
            {
                typeof(BadRequestObjectResult),
                new CalculationViewModel()
            };

            yield return new object[]
            {
                typeof(BadRequestObjectResult),
                new CalculationViewModel
                {
                    Experience = 0,
                    Function = "CTO",
                    Region = "Denver1"
                }
            };

            yield return new object[]
            {
                typeof(BadRequestObjectResult),
                null
            };

            yield return new object[]
            {
                typeof(OkObjectResult),
                new CalculationViewModel
                {
                    Experience = 10,
                    Function = "Developer",
                    Region = "New York"
                },
                74800,
                126000
            };

            yield return new object[]
            {
                typeof(BadRequestObjectResult),
                new CalculationViewModel
                {
                    Experience = 23,
                    Function = "Developer",
                    Region = "New York"
                },
                74800,
                126000
            };

            yield return new object[]
            {
                typeof(OkObjectResult),
                new CalculationViewModel
                {
                    Experience = 2,
                    Function = "Team lead",
                    Region = "Boston"
                },
                44550,
                72250
            };
        }
    }
}