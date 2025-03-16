using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class Humans
{
    public int Id { get; set; }

    /// <summary>
    /// გვარი
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// სახელი
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// ნამდვილი სახელი
    /// </summary>
    public string? LegalName { get; set; }

    /// <summary>
    /// პირადი ნომერი
    /// </summary>
    public string PersonalId { get; set; } = null!;

    /// <summary>
    /// ტელეფონის ნომერი
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// ელექტრონული ფოსტა
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// იურიდიული მისამართი
    /// </summary>
    public string? LegalAddress { get; set; }

    /// <summary>
    /// ფაქტიური მისამართი
    /// </summary>
    public string? ActualAddress { get; set; }

    /// <summary>
    /// დასაქმება
    /// </summary>
    public string? Employment { get; set; }

    /// <summary>
    /// დაბადების თარიღი
    /// </summary>
    public DateTime? BirthDate { get; set; }

    public virtual ICollection<AdStuffContracts> AdStuffContracts { get; set; } = new List<AdStuffContracts>();

    public virtual ICollection<StudentContract> StudentContractsParentH { get; set; } = new List<StudentContract>();

    public virtual ICollection<StudentContract> StudentContractsStudentH { get; set; } = new List<StudentContract>();

    public virtual ICollection<TeacherContracts> TeacherContracts { get; set; } = new List<TeacherContracts>();
}