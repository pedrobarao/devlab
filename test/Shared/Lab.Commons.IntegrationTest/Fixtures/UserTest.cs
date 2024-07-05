using System.Text.Json.Serialization;

namespace Lab.Commons.IntegrationTest.Fixtures;

public class UserTest

{
    [JsonPropertyName("access_token")] public string AccessToken { get; set; }
}