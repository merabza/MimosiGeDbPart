using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class RsQuoteTypeTests
{
    private static RsQuoteType CreateRsQuoteType(int id = 3)
    {
        return new RsQuoteType
        {
            QtId = id,
            QtName = "ხელფასი"
        };
    }

    private static RsQuoteType CreateOtherRsQuoteType(int id = 3)
    {
        return new RsQuoteType
        {
            QtId = id,
            QtName = "პრემია"
        };
    }

    [Fact]
    public void Id_Get_ReturnsQtId()
    {
        // Arrange
        RsQuoteType rsQuoteType = CreateRsQuoteType(3);

        // Act
        int id = rsQuoteType.Id;

        // Assert
        Assert.Equal(3, id);
    }

    [Fact]
    public void Id_Set_SetsQtId()
    {
        // Arrange
        RsQuoteType rsQuoteType = CreateRsQuoteType(3);

        // Act
        rsQuoteType.Id = 5;

        // Assert
        Assert.Equal(5, rsQuoteType.QtId);
    }

    [Fact]
    public void Key_Always_ReturnsNull()
    {
        // Arrange
        RsQuoteType rsQuoteType = CreateRsQuoteType();

        // Act
        string? key = rsQuoteType.Key;

        // Assert
        Assert.Null(key);
    }

    [Fact]
    public void Name_Get_ReturnsQtName()
    {
        // Arrange
        RsQuoteType rsQuoteType = CreateRsQuoteType();

        // Act
        string? name = rsQuoteType.Name;

        // Assert
        Assert.Equal("ხელფასი", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        RsQuoteType rsQuoteType = CreateRsQuoteType();

        // Act
        int? parentId = rsQuoteType.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithRsQuoteType_ReturnsTrue()
    {
        // Arrange
        RsQuoteType rsQuoteType = CreateRsQuoteType();

        // Act
        bool result = rsQuoteType.UpdateTo(CreateOtherRsQuoteType());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithRsQuoteType_CopiesEditableFields()
    {
        // Arrange
        RsQuoteType rsQuoteType = CreateRsQuoteType();

        // Act
        rsQuoteType.UpdateTo(CreateOtherRsQuoteType());

        // Assert
        Assert.Equal("პრემია", rsQuoteType.QtName);
    }

    [Fact]
    public void UpdateTo_WithRsQuoteTypeHavingOtherId_KeepsOwnId()
    {
        // Arrange
        RsQuoteType rsQuoteType = CreateRsQuoteType(3);

        // Act
        rsQuoteType.UpdateTo(CreateOtherRsQuoteType(4));

        // Assert
        Assert.Equal(3, rsQuoteType.QtId);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        RsQuoteType rsQuoteType = CreateRsQuoteType();

        // Act
        bool result = rsQuoteType.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        RsQuoteType rsQuoteType = CreateRsQuoteType();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        rsQuoteType.UpdateTo(otherData);

        // Assert
        Assert.Equal("ხელფასი", rsQuoteType.QtName);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        RsQuoteType rsQuoteType = CreateRsQuoteType(3);

        // Act
        object fields = rsQuoteType.EditFields();

        // Assert
        RsQuoteType copy = Assert.IsType<RsQuoteType>(fields);
        Assert.NotSame(rsQuoteType, copy);
        Assert.Equal(3, copy.QtId);
        Assert.Equal("ხელფასი", copy.QtName);
    }
}
