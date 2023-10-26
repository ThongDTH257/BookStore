using Newtonsoft.Json;

namespace BookStoreClient.Models
{
    public class OData<T>
    {
        [JsonProperty("@odata.context")]
        public string Metadata { get; set; }
        public T value { get; set; }
    }
}
