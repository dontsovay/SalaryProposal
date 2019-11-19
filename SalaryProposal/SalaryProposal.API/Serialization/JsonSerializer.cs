using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SalaryProposal.API.Serialization
{
    /// <summary></summary>
    public sealed class JsonSerializer
    {
        /// <summary>The settings</summary>
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new JsonContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        /// <summary>Serializes the object.</summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static string SerializeObject(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented, Settings);
        }

        /// <summary></summary>
        /// <seealso cref="Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver" />
        public sealed class JsonContractResolver : CamelCasePropertyNamesContractResolver { }
    }
}
