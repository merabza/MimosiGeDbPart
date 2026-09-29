using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class GroupSizeTests
{
    private static GroupSize CreateGroupSize(int id = 3)
    {
        return new GroupSize
        {
            GrsId = id,
            GrsSize = 8,
            GrsName = "მცირე"
        };
    }

    private static GroupSize CreateOtherGroupSize(int id = 3)
    {
        return new GroupSize
        {
            GrsId = id,
            GrsSize = 12,
            GrsName = "დიდი"
        };
    }

    [Fact]
    public void Id_Get_ReturnsGrsId()
    {
        // Arrange
        GroupSize groupSize = CreateGroupSize(3);

        // Act
        int id = groupSize.Id;

        // Assert
        Assert.Equal(3, id);
    }

    [Fact]
    public void Id_Set_SetsGrsId()
    {
        // Arrange
        GroupSize groupSize = CreateGroupSize(3);

        // Act
        groupSize.Id = 5;

        // Assert
        Assert.Equal(5, groupSize.GrsId);
    }

    [Fact]
    public void Key_Always_ReturnsNull()
    {
        // Arrange
        GroupSize groupSize = CreateGroupSize();

        // Act
        string? key = groupSize.Key;

        // Assert
        Assert.Null(key);
    }

    [Fact]
    public void Name_Get_ReturnsGrsName()
    {
        // Arrange
        GroupSize groupSize = CreateGroupSize();

        // Act
        string? name = groupSize.Name;

        // Assert
        Assert.Equal("მცირე", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        GroupSize groupSize = CreateGroupSize();

        // Act
        int? parentId = groupSize.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithGroupSize_ReturnsTrue()
    {
        // Arrange
        GroupSize groupSize = CreateGroupSize();

        // Act
        bool result = groupSize.UpdateTo(CreateOtherGroupSize());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithGroupSize_CopiesEditableFields()
    {
        // Arrange
        GroupSize groupSize = CreateGroupSize();

        // Act
        groupSize.UpdateTo(CreateOtherGroupSize());

        // Assert
        Assert.Equal(12, groupSize.GrsSize);
        Assert.Equal("დიდი", groupSize.GrsName);
    }

    [Fact]
    public void UpdateTo_WithGroupSizeHavingOtherId_KeepsOwnId()
    {
        // Arrange
        GroupSize groupSize = CreateGroupSize(3);

        // Act
        groupSize.UpdateTo(CreateOtherGroupSize(4));

        // Assert
        Assert.Equal(3, groupSize.GrsId);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        GroupSize groupSize = CreateGroupSize();

        // Act
        bool result = groupSize.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        GroupSize groupSize = CreateGroupSize();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        groupSize.UpdateTo(otherData);

        // Assert
        Assert.Equal(8, groupSize.GrsSize);
        Assert.Equal("მცირე", groupSize.GrsName);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        GroupSize groupSize = CreateGroupSize(3);

        // Act
        object fields = groupSize.EditFields();

        // Assert
        GroupSize copy = Assert.IsType<GroupSize>(fields);
        Assert.NotSame(groupSize, copy);
        Assert.Equal(3, copy.GrsId);
        Assert.Equal(8, copy.GrsSize);
        Assert.Equal("მცირე", copy.GrsName);
    }
}
