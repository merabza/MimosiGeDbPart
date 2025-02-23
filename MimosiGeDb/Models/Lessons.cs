using System;

namespace MimosiGeDb.Models;

public partial class Lessons
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int TeacherContractId { get; set; }

    public int? SubstituteTeacherContractId { get; set; }

    public DateTime LessonDt { get; set; }

    public int SalarySchemaId { get; set; }

    public float FourWeekHours { get; set; }

    public int Status { get; set; }

    public string? Note { get; set; }

    public int TeacherLateMinutes { get; set; }

    public DateTime? RecoverDate { get; set; }

    public DateTime TeoMinDate { get; set; }

    public DateTime TeoMaxDate { get; set; }
}