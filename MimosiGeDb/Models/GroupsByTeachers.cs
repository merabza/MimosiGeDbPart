using System;

namespace MimosiGeDb.Models;

public partial class GroupsByTeachers
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int TeacherContractId { get; set; }

    public int SalarySchemaId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}