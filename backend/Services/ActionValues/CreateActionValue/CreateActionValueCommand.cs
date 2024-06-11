namespace Services.ActionValues.CreateActionValue;

public class CreateActionValueCommand
{
    public Guid AudioTranscriptionId { get; set; }

    public ActionEnum Action { get; set; }

    public int Value { get; set; }

    public string UnitCategory { get; set; } = string.Empty;
}
