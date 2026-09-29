using System;
using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class HumanTests
{
    private static Human CreateHuman(int id = 3)
    {
        return new Human
        {
            HumId = id,
            LastName = "გვარი1",
            FirstName = "სახელი1",
            LegalName = null,
            PersonalId = "01234567890",
            PhoneNumber = "555000111",
            Email = "a@example.com",
            LegalAddress = "მისამართი 1",
            ActualAddress = "ფაქტიური 1",
            Employment = "სკოლა",
            BirthDate = new DateTime(2010, 5, 1, 0, 0, 0, DateTimeKind.Unspecified)
        };
    }

    private static Human CreateOtherHuman(int id = 3)
    {
        return new Human
        {
            HumId = id,
            LastName = "გვარი2",
            FirstName = "სახელი2",
            LegalName = "იურიდიული სახელი",
            PersonalId = "09876543210",
            PhoneNumber = "599000222",
            Email = "b@example.com",
            LegalAddress = "მისამართი 2",
            ActualAddress = "ფაქტიური 2",
            Employment = "უნივერსიტეტი",
            BirthDate = new DateTime(2011, 6, 2, 0, 0, 0, DateTimeKind.Unspecified)
        };
    }

    [Fact]
    public void Id_Get_ReturnsHumId()
    {
        // Arrange
        Human human = CreateHuman(3);

        // Act
        int id = human.Id;

        // Assert
        Assert.Equal(3, id);
    }

    [Fact]
    public void Id_Set_SetsHumId()
    {
        // Arrange
        Human human = CreateHuman(3);

        // Act
        human.Id = 5;

        // Assert
        Assert.Equal(5, human.HumId);
    }

    [Fact]
    public void Key_Get_ReturnsPersonalId()
    {
        // Arrange
        Human human = CreateHuman();

        // Act
        string? key = human.Key;

        // Assert
        Assert.Equal("01234567890", key);
    }

    [Fact]
    public void Name_Get_ReturnsLastNameAndFirstName()
    {
        // Arrange
        Human human = CreateHuman();

        // Act
        string? name = human.Name;

        // Assert
        Assert.Equal("გვარი1 სახელი1", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        Human human = CreateHuman();

        // Act
        int? parentId = human.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithHuman_ReturnsTrue()
    {
        // Arrange
        Human human = CreateHuman();

        // Act
        bool result = human.UpdateTo(CreateOtherHuman());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithHuman_CopiesEditableFields()
    {
        // Arrange
        Human human = CreateHuman();

        // Act
        human.UpdateTo(CreateOtherHuman());

        // Assert
        Assert.Equal("გვარი2", human.LastName);
        Assert.Equal("სახელი2", human.FirstName);
        Assert.Equal("იურიდიული სახელი", human.LegalName);
        Assert.Equal("09876543210", human.PersonalId);
        Assert.Equal("599000222", human.PhoneNumber);
        Assert.Equal("b@example.com", human.Email);
        Assert.Equal("მისამართი 2", human.LegalAddress);
        Assert.Equal("ფაქტიური 2", human.ActualAddress);
        Assert.Equal("უნივერსიტეტი", human.Employment);
        Assert.Equal(new DateTime(2011, 6, 2, 0, 0, 0, DateTimeKind.Unspecified), human.BirthDate);
    }

    [Fact]
    public void UpdateTo_WithHumanHavingOtherId_KeepsOwnId()
    {
        // Arrange
        Human human = CreateHuman(3);

        // Act
        human.UpdateTo(CreateOtherHuman(4));

        // Assert
        Assert.Equal(3, human.HumId);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        Human human = CreateHuman();

        // Act
        bool result = human.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        Human human = CreateHuman();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        human.UpdateTo(otherData);

        // Assert
        Assert.Equal("გვარი1", human.LastName);
        Assert.Equal("სახელი1", human.FirstName);
        Assert.Null(human.LegalName);
        Assert.Equal("01234567890", human.PersonalId);
        Assert.Equal("555000111", human.PhoneNumber);
        Assert.Equal("a@example.com", human.Email);
        Assert.Equal("მისამართი 1", human.LegalAddress);
        Assert.Equal("ფაქტიური 1", human.ActualAddress);
        Assert.Equal("სკოლა", human.Employment);
        Assert.Equal(new DateTime(2010, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), human.BirthDate);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        Human human = CreateHuman(3);

        // Act
        object fields = human.EditFields();

        // Assert
        Human copy = Assert.IsType<Human>(fields);
        Assert.NotSame(human, copy);
        Assert.Equal(3, copy.HumId);
        Assert.Equal("გვარი1", copy.LastName);
        Assert.Equal("სახელი1", copy.FirstName);
        Assert.Null(copy.LegalName);
        Assert.Equal("01234567890", copy.PersonalId);
        Assert.Equal("555000111", copy.PhoneNumber);
        Assert.Equal("a@example.com", copy.Email);
        Assert.Equal("მისამართი 1", copy.LegalAddress);
        Assert.Equal("ფაქტიური 1", copy.ActualAddress);
        Assert.Equal("სკოლა", copy.Employment);
        Assert.Equal(new DateTime(2010, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), copy.BirthDate);
    }
}
