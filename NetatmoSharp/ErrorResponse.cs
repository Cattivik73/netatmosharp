using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace NetatmoSharp
{
    public class ErrorResponse
    {
        [JsonPropertyName("error")]
        public ErrorDetail Error { get; set; }
    }

    public class ErrorDetail
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}


