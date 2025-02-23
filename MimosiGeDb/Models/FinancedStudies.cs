using System;

namespace MimosiGeDb.Models;

public partial class FinancedStudies
{
    public int FsId { get; set; }

    public int TeacherContractId { get; set; }

    public DateTime ForMonth { get; set; }

    public decimal FsStudyAmount { get; set; }

    public decimal FsOurAmount { get; set; }
}