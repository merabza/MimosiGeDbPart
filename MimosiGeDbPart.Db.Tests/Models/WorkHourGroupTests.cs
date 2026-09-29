using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class WorkHourGroupTests
{
    private static WorkHourGroup CreateWorkHourGroup(int id = 3)
    {
        return new WorkHourGroup
        {
            WhgId = id,
            WhgKey = "Admin",
            WhgName = "ადმინისტრაცია",
            WhgSalaryNet = 1000m
        };
    }

    private static WorkHourGroup CreateOtherWorkHourGroup(int id = 3)
    {
        return new WorkHourGroup
        {
            WhgId = id,
            WhgKey = "Other",
            WhgName = "სხვა",
            WhgSalaryNet = 1200.5m
        };
    }

    [Fact]
    public void Id_Get_ReturnsWhgId()
    {
        // Arrange
        WorkHourGroup workHourGroup = CreateWorkHourGroup(3);

        // Act
        int id = workHourGroup.Id;

        // Assert
        Assert.Equal(3, id);
    }

    [Fact]
    public void Id_Set_SetsWhgId()
    {
        // Arrange
        WorkHourGroup workHourGroup = CreateWorkHourGroup(3);

        // Act
        workHourGroup.Id = 5;

        // Assert
        Assert.Equal(5, workHourGroup.WhgId);
    }

    [Fact]
    public void Key_Get_ReturnsWhgKey()
    {
        // Arrange
        WorkHourGroup workHourGroup = CreateWorkHourGroup();

        // Act
        string? key = workHourGroup.Key;

        // Assert
        Assert.Equal("Admin", key);
    }

    [Fact]
    public void Name_Get_ReturnsWhgName()
    {
        // Arrange
        WorkHourGroup workHourGroup = CreateWorkHourGroup();

        // Act
        string? name = workHourGroup.Name;

        // Assert
        Assert.Equal("ადმინისტრაცია", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        WorkHourGroup workHourGroup = CreateWorkHourGroup();

        // Act
        int? parentId = workHourGroup.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithWorkHourGroup_ReturnsTrue()
    {
        // Arrange
        WorkHourGroup workHourGroup = CreateWorkHourGroup();

        // Act
        bool result = workHourGroup.UpdateTo(CreateOtherWorkHourGroup());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithWorkHourGroup_CopiesEditableFields()
    {
        // Arrange
        WorkHourGroup workHourGroup = CreateWorkHourGroup();

        // Act
        workHourGroup.UpdateTo(CreateOtherWorkHourGroup());

        // Assert
        Assert.Equal("Other", workHourGroup.WhgKey);
        Assert.Equal("სხვა", workHourGroup.WhgName);
        Assert.Equal(1200.5m, workHourGroup.WhgSalaryNet);
    }

    [Fact]
    public void UpdateTo_WithWorkHourGroupHavingOtherId_KeepsOwnId()
    {
        // Arrange
        WorkHourGroup workHourGroup = CreateWorkHourGroup(3);

        // Act
        workHourGroup.UpdateTo(CreateOtherWorkHourGroup(4));

        // Assert
        Assert.Equal(3, workHourGroup.WhgId);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        WorkHourGroup workHourGroup = CreateWorkHourGroup();

        // Act
        bool result = workHourGroup.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        WorkHourGroup workHourGroup = CreateWorkHourGroup();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        workHourGroup.UpdateTo(otherData);

        // Assert
        Assert.Equal("Admin", workHourGroup.WhgKey);
        Assert.Equal("ადმინისტრაცია", workHourGroup.WhgName);
        Assert.Equal(1000m, workHourGroup.WhgSalaryNet);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        WorkHourGroup workHourGroup = CreateWorkHourGroup(3);

        // Act
        object fields = workHourGroup.EditFields();

        // Assert
        WorkHourGroup copy = Assert.IsType<WorkHourGroup>(fields);
        Assert.NotSame(workHourGroup, copy);
        Assert.Equal(3, copy.WhgId);
        Assert.Equal("Admin", copy.WhgKey);
        Assert.Equal("ადმინისტრაცია", copy.WhgName);
        Assert.Equal(1000m, copy.WhgSalaryNet);
    }
}
