using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SalaryProposal.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalaryProposal.Infrastructure.Dto.Requests
{
    public class FilterRequest
    {
        /// <summary>Gets or sets the limit.</summary>
        /// <value>The limit.</value>
        public int? Limit { get; set; }

        /// <summary>Gets or sets the offset.</summary>
        /// <value>The offset.</value>
        public int? Offset { get; set; }

        /// <summary>Gets or sets the sort.</summary>
        /// <value>The sort.</value>
        public string Sort { get; set; }

        /// <summary>Gets or sets the global like.</summary>
        /// <value>The global like.</value>
        public string GlobalLike { get; set; }

        /// <summary>Gets or sets the type of the sort.</summary>
        /// <value>The type of the sort.</value>
        [EnumDataType(typeof(SortType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public SortType SortType { get; set; } = SortType.Asc;
    }
}
