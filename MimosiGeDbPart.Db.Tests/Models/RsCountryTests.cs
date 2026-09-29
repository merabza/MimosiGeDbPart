using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class RsCountryTests
{
    private static RsCountry CreateRsCountry(int id = 3)
    {
        return new RsCountry
        {
            Id = id,
            Code = "268",
            CountryName = "საქართველო"
        };
    }

    private static RsCountry CreateOtherRsCountry(int id = 3)
    {
        return new RsCountry
        {
            Id = id,
            Code = "840",
            CountryName = "აშშ"
        };
    }

    [Fact]
    public void Key_Get_ReturnsCode()
    {
        // Arrange
        RsCountry rsCountry = CreateRsCountry();

        // Act
        string? key = rsCountry.Key;

        // Assert
        Assert.Equal("268", key);
    }

    [Fact]
    public void Name_Get_ReturnsCountryName()
    {
        // Arrange
        RsCountry rsCountry = CreateRsCountry();

        // Act
        string? name = rsCountry.Name;

        // Assert
        Assert.Equal("საქართველო", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        RsCountry rsCountry = CreateRsCountry();

        // Act
        int? parentId = rsCountry.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithRsCountry_ReturnsTrue()
    {
        // Arrange
        RsCountry rsCountry = CreateRsCountry();

        // Act
        bool result = rsCountry.UpdateTo(CreateOtherRsCountry());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithRsCountry_CopiesEditableFields()
    {
        // Arrange
        RsCountry rsCountry = CreateRsCountry();

        // Act
        rsCountry.UpdateTo(CreateOtherRsCountry());

        // Assert
        Assert.Equal("840", rsCountry.Code);
        Assert.Equal("აშშ", rsCountry.CountryName);
    }

    [Fact]
    public void UpdateTo_WithRsCountryHavingOtherId_KeepsOwnId()
    {
        // Arrange
        RsCountry rsCountry = CreateRsCountry(3);

        // Act
        rsCountry.UpdateTo(CreateOtherRsCountry(4));

        // Assert
        Assert.Equal(3, rsCountry.Id);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        RsCountry rsCountry = CreateRsCountry();

        // Act
        bool result = rsCountry.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        RsCountry rsCountry = CreateRsCountry();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        rsCountry.UpdateTo(otherData);

        // Assert
        Assert.Equal("268", rsCountry.Code);
        Assert.Equal("საქართველო", rsCountry.CountryName);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        RsCountry rsCountry = CreateRsCountry(3);

        // Act
        object fields = rsCountry.EditFields();

        // Assert
        RsCountry copy = Assert.IsType<RsCountry>(fields);
        Assert.NotSame(rsCountry, copy);
        Assert.Equal(3, copy.Id);
        Assert.Equal("268", copy.Code);
        Assert.Equal("საქართველო", copy.CountryName);
    }
}
