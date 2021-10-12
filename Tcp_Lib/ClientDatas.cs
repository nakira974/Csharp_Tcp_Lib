using System.Text.Json.Serialization;

namespace Tcp_Lib
{
    public record ClientDatas()
    {
        [JsonPropertyName("CurrentClientSignal")]
        public Signals CurrentClientSignal { get; set; }
        [JsonPropertyName("ClientName")]
        public string ClientName { get; init; }
        
    };
}