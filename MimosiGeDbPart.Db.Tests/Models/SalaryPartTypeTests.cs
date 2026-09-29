using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class SalaryPartTypeTests
{
    private static SalaryPartType CreateSalaryPartType(int id = 3)
    {
        return new SalaryPartType
        {
            SptId = id,
            SptName = "დანამატი",
            SptCountPlaceId = 1,
            RsQuoteTypeId = 1
        };
    }

    private static SalaryPartType CreateOtherSalaryPartType(int id = 3)
    {
        return new SalaryPartType
        {
            SptId = id,
            SptName = "გამოქვითვა",
            SptCountPlaceId = 2,
            RsQuoteTypeId = 21
        };
    }

    [Fact]
    public void Id_Get_ReturnsSptId()
    {
        // Arrange
        SalaryPartType salaryPartType = CreateSalaryPartType(3);

        // Act
        int id = salaryPartType.Id;

        // Assert
        Assert.Equal(3, id);
    }

    [Fact]
    public void Id_Set_SetsSptId()
    {
        // Arrange
        SalaryPartType salaryPartType = CreateSalaryPartType(3);

        // Act
        salaryPartType.Id = 5;

        // Assert
        Assert.Equal(5, salaryPartType.SptId);
    }

    [Fact]
    public void Key_Always_ReturnsNull()
    {
        // Arrange
        SalaryPartType salaryPartType = CreateSalaryPartType();

        // Act
        string? key = salaryPartType.Key;

        // Assert
        Assert.Null(key);
    }

    [Fact]
    public void Name_Get_ReturnsSptName()
    {
        // Arrange
        SalaryPartType salaryPartType = CreateSalaryPartType();

        // Act
        string? name = salaryPartType.Name;

        // Assert
        Assert.Equal("დანამატი", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        SalaryPartType salaryPartType = CreateSalaryPartType();

        // Act
        int? parentId = salaryPartType.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithSalaryPartType_ReturnsTrue()
    {
        // Arrange
        SalaryPartType salaryPartType = CreateSalaryPartType();

        // Act
        bool result = salaryPartType.UpdateTo(CreateOtherSalaryPartType());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithSalaryPartType_CopiesEditableFields()
    {
        // Arrange
        SalaryPartType salaryPartType = CreateSalaryPartType();

        // Act
        salaryPartType.UpdateTo(CreateOtherSalaryPartType());

        // Assert
        Assert.Equal("გამოქვითვა", salaryPartType.SptName);
        Assert.Equal(2, salaryPartType.SptCountPlaceId);
        Assert.Equal(21, salaryPartType.RsQuoteTypeId);
    }

    [Fact]
    public void UpdateTo_WithSalaryPartTypeHavingOtherId_KeepsOwnId()
    {
        // Arrange
        SalaryPartType salaryPartType = CreateSalaryPartType(3);

        // Act
        salaryPartType.UpdateTo(CreateOtherSalaryPartType(4));

        // Assert
        Assert.Equal(3, salaryPartType.SptId);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        SalaryPartType salaryPartType = CreateSalaryPartType();

        // Act
        bool result = salaryPartType.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        SalaryPartType salaryPartType = CreateSalaryPartType();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        salaryPartType.UpdateTo(otherData);

        // Assert
        Assert.Equal("დანამატი", salaryPartType.SptName);
        Assert.Equal(1, salaryPartType.SptCountPlaceId);
        Assert.Equal(1, salaryPartType.RsQuoteTypeId);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        SalaryPartType salaryPartType = CreateSalaryPartType(3);

        // Act
        object fields = salaryPartType.EditFields();

        // Assert
        SalaryPartType copy = Assert.IsType<SalaryPartType>(fields);
        Assert.NotSame(salaryPartType, copy);
        Assert.Equal(3, copy.SptId);
        Assert.Equal("დანამატი", copy.SptName);
        Assert.Equal(1, copy.SptCountPlaceId);
        Assert.Equal(1, copy.RsQuoteTypeId);
    }
}
