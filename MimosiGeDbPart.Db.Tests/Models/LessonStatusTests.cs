using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class LessonStatusTests
{
    private static LessonStatus CreateLessonStatus(int id = 3)
    {
        return new LessonStatus
        {
            Id = id,
            StatusName = "არ გაუქმებულა"
        };
    }

    private static LessonStatus CreateOtherLessonStatus(int id = 3)
    {
        return new LessonStatus
        {
            Id = id,
            StatusName = "გაუქმდა"
        };
    }

    [Fact]
    public void Key_Always_ReturnsNull()
    {
        // Arrange
        LessonStatus lessonStatus = CreateLessonStatus();

        // Act
        string? key = lessonStatus.Key;

        // Assert
        Assert.Null(key);
    }

    [Fact]
    public void Name_Get_ReturnsStatusName()
    {
        // Arrange
        LessonStatus lessonStatus = CreateLessonStatus();

        // Act
        string? name = lessonStatus.Name;

        // Assert
        Assert.Equal("არ გაუქმებულა", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        LessonStatus lessonStatus = CreateLessonStatus();

        // Act
        int? parentId = lessonStatus.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithLessonStatus_ReturnsTrue()
    {
        // Arrange
        LessonStatus lessonStatus = CreateLessonStatus();

        // Act
        bool result = lessonStatus.UpdateTo(CreateOtherLessonStatus());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithLessonStatus_CopiesEditableFields()
    {
        // Arrange
        LessonStatus lessonStatus = CreateLessonStatus();

        // Act
        lessonStatus.UpdateTo(CreateOtherLessonStatus());

        // Assert
        Assert.Equal("გაუქმდა", lessonStatus.StatusName);
    }

    [Fact]
    public void UpdateTo_WithLessonStatusHavingOtherId_KeepsOwnId()
    {
        // Arrange
        LessonStatus lessonStatus = CreateLessonStatus(3);

        // Act
        lessonStatus.UpdateTo(CreateOtherLessonStatus(4));

        // Assert
        Assert.Equal(3, lessonStatus.Id);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        LessonStatus lessonStatus = CreateLessonStatus();

        // Act
        bool result = lessonStatus.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        LessonStatus lessonStatus = CreateLessonStatus();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        lessonStatus.UpdateTo(otherData);

        // Assert
        Assert.Equal("არ გაუქმებულა", lessonStatus.StatusName);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        LessonStatus lessonStatus = CreateLessonStatus(3);

        // Act
        object fields = lessonStatus.EditFields();

        // Assert
        LessonStatus copy = Assert.IsType<LessonStatus>(fields);
        Assert.NotSame(lessonStatus, copy);
        Assert.Equal(3, copy.Id);
        Assert.Equal("არ გაუქმებულა", copy.StatusName);
    }
}
