using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class GeoMonthTests
{
    private static GeoMonth CreateGeoMonth(int id = 3)
    {
        return new GeoMonth
        {
            GmnId = id,
            GmnName = "იანვარი",
            GmnDative = "იანვრის"
        };
    }

    private static GeoMonth CreateOtherGeoMonth(int id = 3)
    {
        return new GeoMonth
        {
            GmnId = id,
            GmnName = "თებერვალი",
            GmnDative = "თებერვლის"
        };
    }

    [Fact]
    public void Id_Get_ReturnsGmnId()
    {
        // Arrange
        GeoMonth geoMonth = CreateGeoMonth(3);

        // Act
        int id = geoMonth.Id;

        // Assert
        Assert.Equal(3, id);
    }

    [Fact]
    public void Id_Set_SetsGmnId()
    {
        // Arrange
        GeoMonth geoMonth = CreateGeoMonth(3);

        // Act
        geoMonth.Id = 5;

        // Assert
        Assert.Equal(5, geoMonth.GmnId);
    }

    [Fact]
    public void Key_Always_ReturnsNull()
    {
        // Arrange
        GeoMonth geoMonth = CreateGeoMonth();

        // Act
        string? key = geoMonth.Key;

        // Assert
        Assert.Null(key);
    }

    [Fact]
    public void Name_Get_ReturnsGmnName()
    {
        // Arrange
        GeoMonth geoMonth = CreateGeoMonth();

        // Act
        string? name = geoMonth.Name;

        // Assert
        Assert.Equal("იანვარი", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        GeoMonth geoMonth = CreateGeoMonth();

        // Act
        int? parentId = geoMonth.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithGeoMonth_ReturnsTrue()
    {
        // Arrange
        GeoMonth geoMonth = CreateGeoMonth();

        // Act
        bool result = geoMonth.UpdateTo(CreateOtherGeoMonth());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithGeoMonth_CopiesEditableFields()
    {
        // Arrange
        GeoMonth geoMonth = CreateGeoMonth();

        // Act
        geoMonth.UpdateTo(CreateOtherGeoMonth());

        // Assert
        Assert.Equal("თებერვალი", geoMonth.GmnName);
        Assert.Equal("თებერვლის", geoMonth.GmnDative);
    }

    [Fact]
    public void UpdateTo_WithGeoMonthHavingOtherId_KeepsOwnId()
    {
        // Arrange
        GeoMonth geoMonth = CreateGeoMonth(3);

        // Act
        geoMonth.UpdateTo(CreateOtherGeoMonth(4));

        // Assert
        Assert.Equal(3, geoMonth.GmnId);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        GeoMonth geoMonth = CreateGeoMonth();

        // Act
        bool result = geoMonth.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        GeoMonth geoMonth = CreateGeoMonth();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        geoMonth.UpdateTo(otherData);

        // Assert
        Assert.Equal("იანვარი", geoMonth.GmnName);
        Assert.Equal("იანვრის", geoMonth.GmnDative);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        GeoMonth geoMonth = CreateGeoMonth(3);

        // Act
        object fields = geoMonth.EditFields();

        // Assert
        GeoMonth copy = Assert.IsType<GeoMonth>(fields);
        Assert.NotSame(geoMonth, copy);
        Assert.Equal(3, copy.GmnId);
        Assert.Equal("იანვარი", copy.GmnName);
        Assert.Equal("იანვრის", copy.GmnDative);
    }
}
