using System;

namespace MimosiGeDbPart.Db.Models;

public sealed class GroupByTeacher
{
    public int Id { get; set; }

    /// <summary>
    ///     ჯგუფი
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    ///     მასწავლებელი
    /// </summary>
    public int TeacherContractId { get; set; }

    /// <summary>
    ///     ხელფასის სქემა
    /// </summary>
    public int SalarySchemaId { get; set; }

    /// <summary>
    ///     გააქტიურების თარიღი
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    ///     გაუქმების თარიღი
    /// </summary>
    public DateTime? EndDate { get; set; }

    public Group Group { get; set; } = null!;

    public TeacherSalaryScheme SalaryScheme { get; set; } = null!;

    public TeacherContract TeacherContract { get; set; } = null!;
}
