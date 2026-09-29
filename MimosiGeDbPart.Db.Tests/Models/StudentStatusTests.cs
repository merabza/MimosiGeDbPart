using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class StudentStatusTests
{
    private static StudentStatus CreateStudentStatus(int id = 3)
    {
        return new StudentStatus
        {
            Id = id,
            StudentStatusName = "I კლასი",
            Rate = 101
        };
    }

    private static StudentStatus CreateOtherStudentStatus(int id = 3)
    {
        return new StudentStatus
        {
            Id = id,
            StudentStatusName = "II კლასი",
            Rate = 102
        };
    }

    [Fact]
    public void Key_Always_ReturnsNull()
    {
        // Arrange
        StudentStatus studentStatus = CreateStudentStatus();

        // Act
        string? key = studentStatus.Key;

        // Assert
        Assert.Null(key);
    }

    [Fact]
    public void Name_Get_ReturnsStudentStatusName()
    {
        // Arrange
        StudentStatus studentStatus = CreateStudentStatus();

        // Act
        string? name = studentStatus.Name;

        // Assert
        Assert.Equal("I კლასი", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        StudentStatus studentStatus = CreateStudentStatus();

        // Act
        int? parentId = studentStatus.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithStudentStatus_ReturnsTrue()
    {
        // Arrange
        StudentStatus studentStatus = CreateStudentStatus();

        // Act
        bool result = studentStatus.UpdateTo(CreateOtherStudentStatus());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithStudentStatus_CopiesEditableFields()
    {
        // Arrange
        StudentStatus studentStatus = CreateStudentStatus();

        // Act
        studentStatus.UpdateTo(CreateOtherStudentStatus());

        // Assert
        Assert.Equal("II კლასი", studentStatus.StudentStatusName);
        Assert.Equal(102, studentStatus.Rate);
    }

    [Fact]
    public void UpdateTo_WithStudentStatusHavingOtherId_KeepsOwnId()
    {
        // Arrange
        StudentStatus studentStatus = CreateStudentStatus(3);

        // Act
        studentStatus.UpdateTo(CreateOtherStudentStatus(4));

        // Assert
        Assert.Equal(3, studentStatus.Id);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        StudentStatus studentStatus = CreateStudentStatus();

        // Act
        bool result = studentStatus.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        StudentStatus studentStatus = CreateStudentStatus();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        studentStatus.UpdateTo(otherData);

        // Assert
        Assert.Equal("I კლასი", studentStatus.StudentStatusName);
        Assert.Equal(101, studentStatus.Rate);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        StudentStatus studentStatus = CreateStudentStatus(3);

        // Act
        object fields = studentStatus.EditFields();

        // Assert
        StudentStatus copy = Assert.IsType<StudentStatus>(fields);
        Assert.NotSame(studentStatus, copy);
        Assert.Equal(3, copy.Id);
        Assert.Equal("I კლასი", copy.StudentStatusName);
        Assert.Equal(101, copy.Rate);
    }
}
