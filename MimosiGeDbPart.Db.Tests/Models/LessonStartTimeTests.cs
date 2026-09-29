using System;
using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class LessonStartTimeTests
{
    private static LessonStartTime CreateLessonStartTime(int id = 3)
    {
        return new LessonStartTime
        {
            LstId = id,
            LstTime = new TimeOnly(8, 5)
        };
    }

    private static LessonStartTime CreateOtherLessonStartTime(int id = 3)
    {
        return new LessonStartTime
        {
            LstId = id,
            LstTime = new TimeOnly(9, 30)
        };
    }

    [Fact]
    public void Id_Get_ReturnsLstId()
    {
        // Arrange
        LessonStartTime lessonStartTime = CreateLessonStartTime(3);

        // Act
        int id = lessonStartTime.Id;

        // Assert
        Assert.Equal(3, id);
    }

    [Fact]
    public void Id_Set_SetsLstId()
    {
        // Arrange
        LessonStartTime lessonStartTime = CreateLessonStartTime(3);

        // Act
        lessonStartTime.Id = 5;

        // Assert
        Assert.Equal(5, lessonStartTime.LstId);
    }

    [Fact]
    public void Key_Always_ReturnsNull()
    {
        // Arrange
        LessonStartTime lessonStartTime = CreateLessonStartTime();

        // Act
        string? key = lessonStartTime.Key;

        // Assert
        Assert.Null(key);
    }

    [Fact]
    public void Name_Get_ReturnsLstTime()
    {
        // Arrange
        LessonStartTime lessonStartTime = CreateLessonStartTime();

        // Act
        string? name = lessonStartTime.Name;

        // Assert
        Assert.Equal("08:05", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        LessonStartTime lessonStartTime = CreateLessonStartTime();

        // Act
        int? parentId = lessonStartTime.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithLessonStartTime_ReturnsTrue()
    {
        // Arrange
        LessonStartTime lessonStartTime = CreateLessonStartTime();

        // Act
        bool result = lessonStartTime.UpdateTo(CreateOtherLessonStartTime());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithLessonStartTime_CopiesEditableFields()
    {
        // Arrange
        LessonStartTime lessonStartTime = CreateLessonStartTime();

        // Act
        lessonStartTime.UpdateTo(CreateOtherLessonStartTime());

        // Assert
        Assert.Equal(new TimeOnly(9, 30), lessonStartTime.LstTime);
    }

    [Fact]
    public void UpdateTo_WithLessonStartTimeHavingOtherId_KeepsOwnId()
    {
        // Arrange
        LessonStartTime lessonStartTime = CreateLessonStartTime(3);

        // Act
        lessonStartTime.UpdateTo(CreateOtherLessonStartTime(4));

        // Assert
        Assert.Equal(3, lessonStartTime.LstId);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        LessonStartTime lessonStartTime = CreateLessonStartTime();

        // Act
        bool result = lessonStartTime.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        LessonStartTime lessonStartTime = CreateLessonStartTime();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        lessonStartTime.UpdateTo(otherData);

        // Assert
        Assert.Equal(new TimeOnly(8, 5), lessonStartTime.LstTime);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        LessonStartTime lessonStartTime = CreateLessonStartTime(3);

        // Act
        object fields = lessonStartTime.EditFields();

        // Assert
        LessonStartTime copy = Assert.IsType<LessonStartTime>(fields);
        Assert.NotSame(lessonStartTime, copy);
        Assert.Equal(3, copy.LstId);
        Assert.Equal(new TimeOnly(8, 5), copy.LstTime);
    }

    // MasterDataCrud deserializes the edit form's JSON with Newtonsoft; the time input sends "HH:mm"
    [Theory]
    [InlineData("""{"lstId":7,"lstTime":"08:30"}""")]
    [InlineData("""{"lstId":7,"lstTime":"08:30:00","name":"08:30"}""")]
    public void Deserialize_MasterDataJson_ReadsLstTime(string json)
    {
        // Arrange

        // Act
        LessonStartTime? lessonStartTime = JsonConvert.DeserializeObject<LessonStartTime>(json);

        // Assert
        Assert.NotNull(lessonStartTime);
        Assert.Equal(7, lessonStartTime.LstId);
        Assert.Equal(new TimeOnly(8, 30), lessonStartTime.LstTime);
    }
}
