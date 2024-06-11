namespace Models;

public class ActionValue
{
    public Guid Id { get; set; }

    public Guid AudioTranscriptionId { get; set; }

    public AudioTranscription? AudioTranscription { get; set; }

    public ActionEnum Action { get; set; }

    public int Value { get; set; }

    public string UnitCategory { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
