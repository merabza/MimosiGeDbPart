using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class WeekDayTests
{
    private static WeekDay CreateWeekDay(int id = 3)
    {
        return new WeekDay
        {
            Id = id,
            Name = "ორშაბათი",
            ShortName = "1-ორ",
            WeekDayNumber = 1
        };
    }

    private static WeekDay CreateOtherWeekDay(int id = 3)
    {
        return new WeekDay
        {
            Id = id,
            Name = "სამშაბათი",
            ShortName = "2-სა",
            WeekDayNumber = 2
        };
    }

    [Fact]
    public void Key_Always_ReturnsNull()
    {
        // Arrange
        WeekDay weekDay = CreateWeekDay();

        // Act
        string? key = weekDay.Key;

        // Assert
        Assert.Null(key);
    }

    [Fact]
    public void Name_Get_ReturnsName()
    {
        // Arrange
        WeekDay weekDay = CreateWeekDay();

        // Act
        string? name = weekDay.Name;

        // Assert
        Assert.Equal("ორშაბათი", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        WeekDay weekDay = CreateWeekDay();

        // Act
        int? parentId = weekDay.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithWeekDay_ReturnsTrue()
    {
        // Arrange
        WeekDay weekDay = CreateWeekDay();

        // Act
        bool result = weekDay.UpdateTo(CreateOtherWeekDay());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithWeekDay_CopiesEditableFields()
    {
        // Arrange
        WeekDay weekDay = CreateWeekDay();

        // Act
        weekDay.UpdateTo(CreateOtherWeekDay());

        // Assert
        Assert.Equal("სამშაბათი", weekDay.Name);
        Assert.Equal("2-სა", weekDay.ShortName);
        Assert.Equal(2, weekDay.WeekDayNumber);
    }

    [Fact]
    public void UpdateTo_WithWeekDayHavingOtherId_KeepsOwnId()
    {
        // Arrange
        WeekDay weekDay = CreateWeekDay(3);

        // Act
        weekDay.UpdateTo(CreateOtherWeekDay(4));

        // Assert
        Assert.Equal(3, weekDay.Id);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        WeekDay weekDay = CreateWeekDay();

        // Act
        bool result = weekDay.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        WeekDay weekDay = CreateWeekDay();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        weekDay.UpdateTo(otherData);

        // Assert
        Assert.Equal("ორშაბათი", weekDay.Name);
        Assert.Equal("1-ორ", weekDay.ShortName);
        Assert.Equal(1, weekDay.WeekDayNumber);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        WeekDay weekDay = CreateWeekDay(3);

        // Act
        object fields = weekDay.EditFields();

        // Assert
        WeekDay copy = Assert.IsType<WeekDay>(fields);
        Assert.NotSame(weekDay, copy);
        Assert.Equal(3, copy.Id);
        Assert.Equal("ორშაბათი", copy.Name);
        Assert.Equal("1-ორ", copy.ShortName);
        Assert.Equal(1, copy.WeekDayNumber);
    }
}
