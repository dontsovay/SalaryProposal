using Microsoft.AspNetCore.Mvc;

namespace SalaryProposal.API.Presenters
{
    /// <summary></summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ContentResult" />
    public sealed class JsonContentResult : ContentResult
    {
        /// <summary>Initializes a new instance of the <see cref="JsonContentResult"/> class.</summary>
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}
