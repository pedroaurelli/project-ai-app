using Database;
using Microsoft.Extensions.Logging;

namespace Services;

public abstract class Service
{
    protected DatabaseContext DbContext { get; } = null!;

    protected ILogger Logger { get; } = null!;
}
