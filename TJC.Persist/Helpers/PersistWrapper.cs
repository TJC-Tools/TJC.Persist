using System.Text.Json;

namespace TJC.Persist.Helpers;

internal class PersistWrapper
{
    public required string Type { get; set; }
    public JsonElement Payload { get; set; }
}
