﻿using System;

namespace MimosiGeDb.Models;

public partial class AdStuffSubstituteTime
{
    public int Id { get; set; }

    public int AdStuffContractId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }
}