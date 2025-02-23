using System;

namespace MimosiGeDb.Models;

public partial class StudentContracts
{
    public int Id { get; set; }

    public string ContractNumber { get; set; } = null!;

    public DateTime ContractDate { get; set; }

    public int StudentHid { get; set; }

    public int ParentHid { get; set; }

    public int AcademicYearId { get; set; }

    public int? StudentStatusId { get; set; }

    public float? DesiredMonthlyPaymentDay { get; set; }

    public DateTime? NextPayDate { get; set; }

    public bool DirtyNextPayDate { get; set; }
}