using System.Linq.Expressions;

namespace Services.ActionValues;

public class ActionValueResult
{
    public ActionValueResult(
        Guid id,
        Guid audioTranscriptionId,
        ActionEnum action,
        int value,
        string unitCategory)
    {
        Id = id;
        AudioTranscriptionId = audioTranscriptionId;
        Action = action;
        Value = value;
        UnitCategory = unitCategory;
    }

    public static Expression<Func<ActionValue, ActionValueResult>> SelectorFromActionValue { get; } =
        actionValue => new ActionValueResult(
            actionValue.Id,
            actionValue.AudioTranscriptionId,
            actionValue.Action,
            actionValue.Value,
            actionValue.UnitCategory);

    public Guid Id { get; set; }

    public Guid AudioTranscriptionId { get; set; }

    public ActionEnum Action { get; set; }

    public int Value { get; set; }

    public string UnitCategory { get; set; }

    public static ActionValueResult FromActionValue(ActionValue actionValue)
    {
        return SelectorFromActionValue.Compile().Invoke(actionValue);
    }
}
