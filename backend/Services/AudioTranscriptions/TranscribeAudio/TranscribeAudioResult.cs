using System.Text.Json.Serialization;

namespace Services.AudioTranscriptions.TranscribeAudio;

public class Result
{
    [JsonPropertyName("action")]
    public required string Action { get; set; }

    [JsonPropertyName("value")]
    public int Value { get; set; }

    [JsonPropertyName("kind")]
    public required string Kind { get; set; }
}

public class TranscribeAudioResult
{
    [JsonPropertyName("results")]
    public required List<Result> Results { get; set; }

    public Guid TranscribedAudioId { get; set; }
}
