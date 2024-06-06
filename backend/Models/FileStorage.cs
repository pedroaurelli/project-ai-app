namespace Models;

public class FileStorage
{
    public Guid Id { get; set; }

    public string Bucket { get; set; } = string.Empty;

    public string Key { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
