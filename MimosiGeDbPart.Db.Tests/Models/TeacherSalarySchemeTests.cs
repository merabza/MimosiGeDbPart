using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class TeacherSalarySchemeTests
{
    private static TeacherSalaryScheme CreateTeacherSalaryScheme(int id = 3)
    {
        return new TeacherSalaryScheme
        {
            Id = id,
            SchemaName = "სქემა 1",
            HourSalaryNet = 10m,
            HourSalaryGross = 12.5m
        };
    }

    private static TeacherSalaryScheme CreateOtherTeacherSalaryScheme(int id = 3)
    {
        return new TeacherSalaryScheme
        {
            Id = id,
            SchemaName = "სქემა 2",
            HourSalaryNet = 12.5m,
            HourSalaryGross = 15.63m
        };
    }

    [Fact]
    public void Key_Always_ReturnsNull()
    {
        // Arrange
        TeacherSalaryScheme teacherSalaryScheme = CreateTeacherSalaryScheme();

        // Act
        string? key = teacherSalaryScheme.Key;

        // Assert
        Assert.Null(key);
    }

    [Fact]
    public void Name_Get_ReturnsSchemaName()
    {
        // Arrange
        TeacherSalaryScheme teacherSalaryScheme = CreateTeacherSalaryScheme();

        // Act
        string? name = teacherSalaryScheme.Name;

        // Assert
        Assert.Equal("სქემა 1", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        TeacherSalaryScheme teacherSalaryScheme = CreateTeacherSalaryScheme();

        // Act
        int? parentId = teacherSalaryScheme.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithTeacherSalaryScheme_ReturnsTrue()
    {
        // Arrange
        TeacherSalaryScheme teacherSalaryScheme = CreateTeacherSalaryScheme();

        // Act
        bool result = teacherSalaryScheme.UpdateTo(CreateOtherTeacherSalaryScheme());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithTeacherSalaryScheme_CopiesEditableFields()
    {
        // Arrange
        TeacherSalaryScheme teacherSalaryScheme = CreateTeacherSalaryScheme();

        // Act
        teacherSalaryScheme.UpdateTo(CreateOtherTeacherSalaryScheme());

        // Assert
        Assert.Equal("სქემა 2", teacherSalaryScheme.SchemaName);
        Assert.Equal(12.5m, teacherSalaryScheme.HourSalaryNet);
        Assert.Equal(15.63m, teacherSalaryScheme.HourSalaryGross);
    }

    [Fact]
    public void UpdateTo_WithTeacherSalarySchemeHavingOtherId_KeepsOwnId()
    {
        // Arrange
        TeacherSalaryScheme teacherSalaryScheme = CreateTeacherSalaryScheme(3);

        // Act
        teacherSalaryScheme.UpdateTo(CreateOtherTeacherSalaryScheme(4));

        // Assert
        Assert.Equal(3, teacherSalaryScheme.Id);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        TeacherSalaryScheme teacherSalaryScheme = CreateTeacherSalaryScheme();

        // Act
        bool result = teacherSalaryScheme.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        TeacherSalaryScheme teacherSalaryScheme = CreateTeacherSalaryScheme();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        teacherSalaryScheme.UpdateTo(otherData);

        // Assert
        Assert.Equal("სქემა 1", teacherSalaryScheme.SchemaName);
        Assert.Equal(10m, teacherSalaryScheme.HourSalaryNet);
        Assert.Equal(12.5m, teacherSalaryScheme.HourSalaryGross);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        TeacherSalaryScheme teacherSalaryScheme = CreateTeacherSalaryScheme(3);

        // Act
        object fields = teacherSalaryScheme.EditFields();

        // Assert
        TeacherSalaryScheme copy = Assert.IsType<TeacherSalaryScheme>(fields);
        Assert.NotSame(teacherSalaryScheme, copy);
        Assert.Equal(3, copy.Id);
        Assert.Equal("სქემა 1", copy.SchemaName);
        Assert.Equal(10m, copy.HourSalaryNet);
        Assert.Equal(12.5m, copy.HourSalaryGross);
    }
}
