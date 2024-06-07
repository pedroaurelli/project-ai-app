namespace Models;

public class AudioTranscription
{
    public Guid Id { get; set; }

    public Guid AudioId { get; set; }

    public Audio? Audio { get; set; }

    public string Text { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
