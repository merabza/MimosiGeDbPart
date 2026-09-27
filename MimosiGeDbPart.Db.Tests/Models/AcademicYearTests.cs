using System;
using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class AcademicYearTests
{
    private static AcademicYear CreateAcademicYear(int ayId = 3)
    {
        return new AcademicYear
        {
            AyId = ayId,
            AcademicYearName = "2025-2026",
            StartDate = new DateTime(2025, 9, 15, 0, 0, 0, DateTimeKind.Unspecified),
            FinishDate = new DateTime(2026, 6, 15, 0, 0, 0, DateTimeKind.Unspecified)
        };
    }

    private static AcademicYear CreateNextAcademicYear(int ayId = 3)
    {
        return new AcademicYear
        {
            AyId = ayId,
            AcademicYearName = "2026-2027",
            StartDate = new DateTime(2026, 9, 15, 0, 0, 0, DateTimeKind.Unspecified),
            FinishDate = new DateTime(2027, 6, 15, 0, 0, 0, DateTimeKind.Unspecified)
        };
    }

    [Fact]
    public void Id_Get_ReturnsAyId()
    {
        // Arrange
        AcademicYear academicYear = CreateAcademicYear(3);

        // Act
        int id = academicYear.Id;

        // Assert
        Assert.Equal(3, id);
    }

    [Fact]
    public void Id_Set_SetsAyId()
    {
        // Arrange
        AcademicYear academicYear = CreateAcademicYear(3);

        // Act
        academicYear.Id = 5;

        // Assert
        Assert.Equal(5, academicYear.AyId);
    }

    [Fact]
    public void Key_Always_ReturnsNull()
    {
        // Arrange
        AcademicYear academicYear = CreateAcademicYear();

        // Act
        string? key = academicYear.Key;

        // Assert
        Assert.Null(key);
    }

    [Fact]
    public void Name_Get_ReturnsAcademicYearName()
    {
        // Arrange
        AcademicYear academicYear = CreateAcademicYear();

        // Act
        string name = academicYear.Name;

        // Assert
        Assert.Equal("2025-2026", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        AcademicYear academicYear = CreateAcademicYear();

        // Act
        int? parentId = academicYear.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithAcademicYear_ReturnsTrue()
    {
        // Arrange
        AcademicYear academicYear = CreateAcademicYear();

        // Act
        bool result = academicYear.UpdateTo(CreateNextAcademicYear());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithAcademicYear_CopiesEditableFields()
    {
        // Arrange
        AcademicYear academicYear = CreateAcademicYear();

        // Act
        academicYear.UpdateTo(CreateNextAcademicYear());

        // Assert
        Assert.Equal("2026-2027", academicYear.AcademicYearName);
        Assert.Equal(new DateTime(2026, 9, 15, 0, 0, 0, DateTimeKind.Unspecified), academicYear.StartDate);
        Assert.Equal(new DateTime(2027, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), academicYear.FinishDate);
    }

    [Fact]
    public void UpdateTo_WithAcademicYearHavingOtherId_KeepsOwnId()
    {
        // Arrange
        AcademicYear academicYear = CreateAcademicYear(3);

        // Act
        academicYear.UpdateTo(CreateNextAcademicYear(4));

        // Assert
        Assert.Equal(3, academicYear.AyId);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        AcademicYear academicYear = CreateAcademicYear();

        // Act
        bool result = academicYear.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        AcademicYear academicYear = CreateAcademicYear();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "2026-2027");

        // Act
        academicYear.UpdateTo(otherData);

        // Assert
        Assert.Equal("2025-2026", academicYear.AcademicYearName);
        Assert.Equal(new DateTime(2025, 9, 15, 0, 0, 0, DateTimeKind.Unspecified), academicYear.StartDate);
        Assert.Equal(new DateTime(2026, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), academicYear.FinishDate);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        AcademicYear academicYear = CreateAcademicYear(3);

        // Act
        object fields = academicYear.EditFields();

        // Assert
        AcademicYear copy = Assert.IsType<AcademicYear>(fields);
        Assert.NotSame(academicYear, copy);
        Assert.Equal(3, copy.AyId);
        Assert.Equal("2025-2026", copy.AcademicYearName);
        Assert.Equal(new DateTime(2025, 9, 15, 0, 0, 0, DateTimeKind.Unspecified), copy.StartDate);
        Assert.Equal(new DateTime(2026, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), copy.FinishDate);
    }
}
