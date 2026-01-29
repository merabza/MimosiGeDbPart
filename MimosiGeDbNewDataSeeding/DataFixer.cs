using Microsoft.Extensions.Logging;

namespace MimosiGeDbNewDataSeeding;

internal sealed class DataFixer
{
    // ReSharper disable once NotAccessedField.Local
#pragma warning disable S4487
    private readonly ILogger _logger;
#pragma warning restore S4487
    // ReSharper disable once NotAccessedField.Local
#pragma warning disable S4487
    private readonly IDataFixRepository _dataFixRepository;
#pragma warning restore S4487

    // ReSharper disable once ConvertToPrimaryConstructor
    public DataFixer(ILogger logger, IDataFixRepository dataFixRepository)
    {
        _logger = logger;
        _dataFixRepository = dataFixRepository;
    }

    // ReSharper disable once MemberCanBeMadeStatic.Global
#pragma warning disable S3400
    public bool Run()
#pragma warning restore S3400
    {
        return true;
    }
}
