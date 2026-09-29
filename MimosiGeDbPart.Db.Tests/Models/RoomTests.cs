using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class RoomTests
{
    private static Room CreateRoom(int id = 3)
    {
        return new Room
        {
            Id = id,
            RoomName = "ოთახი 1"
        };
    }

    private static Room CreateOtherRoom(int id = 3)
    {
        return new Room
        {
            Id = id,
            RoomName = "ოთახი 2"
        };
    }

    [Fact]
    public void Key_Always_ReturnsNull()
    {
        // Arrange
        Room room = CreateRoom();

        // Act
        string? key = room.Key;

        // Assert
        Assert.Null(key);
    }

    [Fact]
    public void Name_Get_ReturnsRoomName()
    {
        // Arrange
        Room room = CreateRoom();

        // Act
        string? name = room.Name;

        // Assert
        Assert.Equal("ოთახი 1", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        Room room = CreateRoom();

        // Act
        int? parentId = room.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithRoom_ReturnsTrue()
    {
        // Arrange
        Room room = CreateRoom();

        // Act
        bool result = room.UpdateTo(CreateOtherRoom());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithRoom_CopiesEditableFields()
    {
        // Arrange
        Room room = CreateRoom();

        // Act
        room.UpdateTo(CreateOtherRoom());

        // Assert
        Assert.Equal("ოთახი 2", room.RoomName);
    }

    [Fact]
    public void UpdateTo_WithRoomHavingOtherId_KeepsOwnId()
    {
        // Arrange
        Room room = CreateRoom(3);

        // Act
        room.UpdateTo(CreateOtherRoom(4));

        // Assert
        Assert.Equal(3, room.Id);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        Room room = CreateRoom();

        // Act
        bool result = room.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        Room room = CreateRoom();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        room.UpdateTo(otherData);

        // Assert
        Assert.Equal("ოთახი 1", room.RoomName);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        Room room = CreateRoom(3);

        // Act
        object fields = room.EditFields();

        // Assert
        Room copy = Assert.IsType<Room>(fields);
        Assert.NotSame(room, copy);
        Assert.Equal(3, copy.Id);
        Assert.Equal("ოთახი 1", copy.RoomName);
    }
}
