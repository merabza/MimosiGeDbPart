﻿using Microsoft.Extensions.Logging;

namespace MimosiGeDbNewDataSeeding;

internal sealed class DataFixer
{
    private readonly ILogger _logger;
    private readonly IDataFixRepository _dataFixRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public DataFixer(ILogger logger, IDataFixRepository dataFixRepository)
    {
        _logger = logger;
        _dataFixRepository = dataFixRepository;
    }

    public bool Run()
    {
        return true;
    }
}