using System;

namespace MimosiGeDb.Models;

public partial class SalaryHeaders
{
    public int ShId { get; set; }

    public DateTime ShChargeDate { get; set; }

    public DateTime ShTransferDate { get; set; }
}