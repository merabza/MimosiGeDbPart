using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class CrmAnswerTypeTests
{
    private static CrmAnswerType CreateCrmAnswerType(int id = 3)
    {
        return new CrmAnswerType
        {
            CatId = id,
            CatKey = "Promised",
            AnswerTypeName = "დაგვპირდა"
        };
    }

    private static CrmAnswerType CreateOtherCrmAnswerType(int id = 3)
    {
        return new CrmAnswerType
        {
            CatId = id,
            CatKey = "Refused",
            AnswerTypeName = "უარი თქვა"
        };
    }

    [Fact]
    public void Id_Get_ReturnsCatId()
    {
        // Arrange
        CrmAnswerType crmAnswerType = CreateCrmAnswerType(3);

        // Act
        int id = crmAnswerType.Id;

        // Assert
        Assert.Equal(3, id);
    }

    [Fact]
    public void Id_Set_SetsCatId()
    {
        // Arrange
        CrmAnswerType crmAnswerType = CreateCrmAnswerType(3);

        // Act
        crmAnswerType.Id = 5;

        // Assert
        Assert.Equal(5, crmAnswerType.CatId);
    }

    [Fact]
    public void Key_Get_ReturnsCatKey()
    {
        // Arrange
        CrmAnswerType crmAnswerType = CreateCrmAnswerType();

        // Act
        string? key = crmAnswerType.Key;

        // Assert
        Assert.Equal("Promised", key);
    }

    [Fact]
    public void Name_Get_ReturnsAnswerTypeName()
    {
        // Arrange
        CrmAnswerType crmAnswerType = CreateCrmAnswerType();

        // Act
        string? name = crmAnswerType.Name;

        // Assert
        Assert.Equal("დაგვპირდა", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        CrmAnswerType crmAnswerType = CreateCrmAnswerType();

        // Act
        int? parentId = crmAnswerType.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithCrmAnswerType_ReturnsTrue()
    {
        // Arrange
        CrmAnswerType crmAnswerType = CreateCrmAnswerType();

        // Act
        bool result = crmAnswerType.UpdateTo(CreateOtherCrmAnswerType());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithCrmAnswerType_CopiesEditableFields()
    {
        // Arrange
        CrmAnswerType crmAnswerType = CreateCrmAnswerType();

        // Act
        crmAnswerType.UpdateTo(CreateOtherCrmAnswerType());

        // Assert
        Assert.Equal("Refused", crmAnswerType.CatKey);
        Assert.Equal("უარი თქვა", crmAnswerType.AnswerTypeName);
    }

    [Fact]
    public void UpdateTo_WithCrmAnswerTypeHavingOtherId_KeepsOwnId()
    {
        // Arrange
        CrmAnswerType crmAnswerType = CreateCrmAnswerType(3);

        // Act
        crmAnswerType.UpdateTo(CreateOtherCrmAnswerType(4));

        // Assert
        Assert.Equal(3, crmAnswerType.CatId);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        CrmAnswerType crmAnswerType = CreateCrmAnswerType();

        // Act
        bool result = crmAnswerType.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        CrmAnswerType crmAnswerType = CreateCrmAnswerType();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        crmAnswerType.UpdateTo(otherData);

        // Assert
        Assert.Equal("Promised", crmAnswerType.CatKey);
        Assert.Equal("დაგვპირდა", crmAnswerType.AnswerTypeName);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        CrmAnswerType crmAnswerType = CreateCrmAnswerType(3);

        // Act
        object fields = crmAnswerType.EditFields();

        // Assert
        CrmAnswerType copy = Assert.IsType<CrmAnswerType>(fields);
        Assert.NotSame(crmAnswerType, copy);
        Assert.Equal(3, copy.CatId);
        Assert.Equal("Promised", copy.CatKey);
        Assert.Equal("დაგვპირდა", copy.AnswerTypeName);
    }
}
