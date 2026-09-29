using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class Human : IDataType
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

    [NotMapped]
    public int Id
    {
        get => HumId;
        set => HumId = value;
    }

    [NotMapped] public string Key => PersonalId;

    [NotMapped] public string Name => $"{LastName} {FirstName}";

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not Human other)
        {
            return false;
        }

        LastName = other.LastName;
        FirstName = other.FirstName;
        LegalName = other.LegalName;
        PersonalId = other.PersonalId;
        PhoneNumber = other.PhoneNumber;
        Email = other.Email;
        LegalAddress = other.LegalAddress;
        ActualAddress = other.ActualAddress;
        Employment = other.Employment;
        BirthDate = other.BirthDate;
        return true;
    }

    public dynamic EditFields()
    {
        return new Human
        {
            HumId = HumId,
            LastName = LastName,
            FirstName = FirstName,
            LegalName = LegalName,
            PersonalId = PersonalId,
            PhoneNumber = PhoneNumber,
            Email = Email,
            LegalAddress = LegalAddress,
            ActualAddress = ActualAddress,
            Employment = Employment,
            BirthDate = BirthDate
        };
    }
}
