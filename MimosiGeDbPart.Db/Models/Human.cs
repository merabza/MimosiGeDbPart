using System;
using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class Human
{
    public int HumId { get; set; }

    /// <summary>
    ///     გვარი
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    ///     სახელი
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    ///     ნამდვილი სახელი
    /// </summary>
    public string? LegalName { get; set; }

    /// <summary>
    ///     პირადი ნომერი
    /// </summary>
    public required string PersonalId { get; set; } = null!;

    /// <summary>
    ///     ტელეფონის ნომერი
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    ///     ელექტრონული ფოსტა
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    ///     იურიდიული მისამართი
    /// </summary>
    public string? LegalAddress { get; set; }

    /// <summary>
    ///     ფაქტიური მისამართი
    /// </summary>
    public string? ActualAddress { get; set; }

    /// <summary>
    ///     დასაქმება
    /// </summary>
    public string? Employment { get; set; }

    /// <summary>
    ///     დაბადების თარიღი
    /// </summary>
    public DateTime? BirthDate { get; set; }

    public ICollection<StudentContract> StudentContractsForParents { get; set; } = new List<StudentContract>();

    public ICollection<StudentContract> StudentContractsForStudents { get; set; } = new List<StudentContract>();

    public ICollection<TeacherContract> TeacherContracts { get; set; } = new List<TeacherContract>();
}
