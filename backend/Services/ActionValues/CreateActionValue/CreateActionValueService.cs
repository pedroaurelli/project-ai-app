namespace Services.ActionValues.CreateActionValue;

public class CreateActionValueService : Service
{
    public async Task<ActionValueResult> CreateActionValueAsync(
        CreateActionValueCommand command)
    {
        Console.WriteLine(command);

        var actionValue = new ActionValue
        {
            AudioTranscriptionId = command.AudioTranscriptionId,
            Action = command.Action,
            Value = command.Value,
            UnitCategory = command.UnitCategory,
        };

        DbContext.ActionValues.Add(actionValue);

        await DbContext.SaveChangesAsync();

        return ActionValueResult.FromActionValue(actionValue);
    }
}
