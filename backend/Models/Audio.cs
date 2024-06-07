namespace Models;

public class Audio
{
    public Guid Id { get; set; }

    public string Bucket { get; set; } = string.Empty;

    public string Key { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
