using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class CrmCallTypeTests
{
    private static CrmCallType CreateCrmCallType(int id = 3)
    {
        return new CrmCallType
        {
            CctId = id,
            CallTypeName = "დავალიანება"
        };
    }

    private static CrmCallType CreateOtherCrmCallType(int id = 3)
    {
        return new CrmCallType
        {
            CctId = id,
            CallTypeName = "სხვა"
        };
    }

    [Fact]
    public void Id_Get_ReturnsCctId()
    {
        // Arrange
        CrmCallType crmCallType = CreateCrmCallType(3);

        // Act
        int id = crmCallType.Id;

        // Assert
        Assert.Equal(3, id);
    }

    [Fact]
    public void Id_Set_SetsCctId()
    {
        // Arrange
        CrmCallType crmCallType = CreateCrmCallType(3);

        // Act
        crmCallType.Id = 5;

        // Assert
        Assert.Equal(5, crmCallType.CctId);
    }

    [Fact]
    public void Key_Always_ReturnsNull()
    {
        // Arrange
        CrmCallType crmCallType = CreateCrmCallType();

        // Act
        string? key = crmCallType.Key;

        // Assert
        Assert.Null(key);
    }

    [Fact]
    public void Name_Get_ReturnsCallTypeName()
    {
        // Arrange
        CrmCallType crmCallType = CreateCrmCallType();

        // Act
        string? name = crmCallType.Name;

        // Assert
        Assert.Equal("დავალიანება", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        CrmCallType crmCallType = CreateCrmCallType();

        // Act
        int? parentId = crmCallType.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithCrmCallType_ReturnsTrue()
    {
        // Arrange
        CrmCallType crmCallType = CreateCrmCallType();

        // Act
        bool result = crmCallType.UpdateTo(CreateOtherCrmCallType());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithCrmCallType_CopiesEditableFields()
    {
        // Arrange
        CrmCallType crmCallType = CreateCrmCallType();

        // Act
        crmCallType.UpdateTo(CreateOtherCrmCallType());

        // Assert
        Assert.Equal("სხვა", crmCallType.CallTypeName);
    }

    [Fact]
    public void UpdateTo_WithCrmCallTypeHavingOtherId_KeepsOwnId()
    {
        // Arrange
        CrmCallType crmCallType = CreateCrmCallType(3);

        // Act
        crmCallType.UpdateTo(CreateOtherCrmCallType(4));

        // Assert
        Assert.Equal(3, crmCallType.CctId);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        CrmCallType crmCallType = CreateCrmCallType();

        // Act
        bool result = crmCallType.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        CrmCallType crmCallType = CreateCrmCallType();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        crmCallType.UpdateTo(otherData);

        // Assert
        Assert.Equal("დავალიანება", crmCallType.CallTypeName);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        CrmCallType crmCallType = CreateCrmCallType(3);

        // Act
        object fields = crmCallType.EditFields();

        // Assert
        CrmCallType copy = Assert.IsType<CrmCallType>(fields);
        Assert.NotSame(crmCallType, copy);
        Assert.Equal(3, copy.CctId);
        Assert.Equal("დავალიანება", copy.CallTypeName);
    }
}
