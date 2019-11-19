using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SalaryProposal.API.Services.Interfaces;
using SalaryProposal.API.ViewModels;
using SalaryProposal.Infrastructure.Configurations;

namespace SalaryProposal.API.Controllers
{
    /// <summary></summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/report")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Authorize(Policy = "ApiUser")]
    public class ReportController : Controller
    {
        /// <summary>The calculation service</summary>
        private readonly ICalculationService _calculationService;

        /// <summary>The environment</summary>
        private readonly IHostingEnvironment _environment;

        /// <summary>Initializes a new instance of the <see cref="ReportController"/> class.</summary>
        /// <param name="calculationService">The calculation service.</param>
        /// <param name="environment">The environment.</param>
        public ReportController(ICalculationService calculationService, IHostingEnvironment environment)
        {
            _calculationService = calculationService;
            _environment = environment;
        }
        
        /// <summary>Generates the specified calculation view model.</summary>
        /// <param name="calculationViewModel">The calculation view model.</param>
        [HttpPost]
        public async Task Generate([FromBody] CalculationViewModel calculationViewModel)
        {
            var experience = (int)calculationViewModel.Experience;
            try
            {
                var result = await _calculationService.Calculate(calculationViewModel);

                var pathRoot = $@"{_environment.ContentRootPath}\Resources\";
                var document = new Document(PageSize.A4, 50, 50, 25, 25);
                var output = new MemoryStream();
                var writer = PdfWriter.GetInstance(document, output);
                document.Open();

                var contents = System.IO.File.ReadAllText($@"{pathRoot}Templates\Report.html")
                    .Replace("[NAME]", $"{calculationViewModel.FirstName} {calculationViewModel.LastName}")
                    .Replace("[DATE]", calculationViewModel.BirthDate.ToShortDateString())
                    .Replace("[EMPLOYEE]", calculationViewModel.EmployeeNumber.ToString(CultureInfo.InvariantCulture))
                    .Replace("[FUNCTION]", calculationViewModel.Function)
                    .Replace("[EXPERIENCE]", $"{experience} {(experience == 1 ? "year" : "years")}")
                    .Replace("[REGION]", calculationViewModel.Region)
                    .Replace("[MINSALARY]", result.MinSalary.ToString("C", CultureInfo.CurrentCulture))
                    .Replace("[MAXSALARY]", result.MaxSalary.ToString("C", CultureInfo.CurrentCulture));

                var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(contents), null);
                foreach (var htmlElement in parsedHtmlElements)
                    document.Add(htmlElement);

                var logo = Image.GetInstance($"{pathRoot}Wedextim-Logo.png");
                logo.SetAbsolutePosition(420, 790);
                document.Add(logo);

                document.Close();
                Response.ContentType = "application/pdf";
                Response.Headers.Add("Content-Disposition", $"attachment;filename={Report.FileName}");
                var buffer = output.ToArray();
                await Response.Body.WriteAsync(buffer, 0, buffer.Length);
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}