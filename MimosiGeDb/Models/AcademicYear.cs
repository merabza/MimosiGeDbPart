using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.MasterData;

namespace MimosiGeDb.Models;

public sealed class AcademicYear : IDataType
{
    public int AyId { get; set; }

    /// <summary>
    ///     სასწავლო წლის დასახელება
    /// </summary>
    public required string AcademicYearName { get; set; }

    /// <summary>
    ///     სასწავლო წლის დასაწყისი
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    ///     სასწავლო წლის დასასრული
    /// </summary>
    public DateTime FinishDate { get; set; }

    public ICollection<StudentContract> StudentContracts { get; set; } = new List<StudentContract>();

    //[NotMapped] public static string DtKeyKey => nameof(AyId).CountDtKey();

    [NotMapped]
    public int Id
    {
        get => AyId;
        set => AyId = value;
    }

    [NotMapped] public string? Key => null;

    [NotMapped] public string Name => AcademicYearName;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not AcademicYear other)
        {
            return false;
        }

        return AyId == other.AyId && AcademicYearName == other.AcademicYearName && StartDate == other.StartDate &&
               FinishDate == other.FinishDate;
    }

    public dynamic EditFields()
    {
        return new AcademicYear
        {
            AyId = AyId, AcademicYearName = AcademicYearName, StartDate = StartDate, FinishDate = FinishDate
        };
    }
}
