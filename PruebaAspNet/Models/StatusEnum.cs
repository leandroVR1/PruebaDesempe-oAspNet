using System.Text.Json.Serialization;

namespace PruebaAspNet.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusEnum
    {
        pagado,
        pendiente,
        cancelado
    }
}
