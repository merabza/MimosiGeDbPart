using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class CourseTests
{
    private static Course CreateCourse(int crsId = 7)
    {
        return new Course { CrsId = crsId, CourseName = "Math" };
    }

    private static Course CreateChangedCourse(int crsId = 7)
    {
        return new Course { CrsId = crsId, CourseName = "Physics" };
    }

    [Fact]
    public void Id_Get_ReturnsCrsId()
    {
        // Arrange
        Course course = CreateCourse(7);

        // Act
        int id = course.Id;

        // Assert
        Assert.Equal(7, id);
    }

    [Fact]
    public void Id_Set_SetsCrsId()
    {
        // Arrange
        Course course = CreateCourse(7);

        // Act
        course.Id = 9;

        // Assert
        Assert.Equal(9, course.CrsId);
    }

    [Fact]
    public void Key_Always_ReturnsNull()
    {
        // Arrange
        Course course = CreateCourse();

        // Act
        string? key = course.Key;

        // Assert
        Assert.Null(key);
    }

    [Fact]
    public void Name_Get_ReturnsCourseName()
    {
        // Arrange
        Course course = CreateCourse();

        // Act
        string name = course.Name;

        // Assert
        Assert.Equal("Math", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        Course course = CreateCourse();

        // Act
        int? parentId = course.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithCourse_ReturnsTrue()
    {
        // Arrange
        Course course = CreateCourse();

        // Act
        bool result = course.UpdateTo(CreateChangedCourse());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithCourse_CopiesCourseName()
    {
        // Arrange
        Course course = CreateCourse();

        // Act
        course.UpdateTo(CreateChangedCourse());

        // Assert
        Assert.Equal("Physics", course.CourseName);
    }

    [Fact]
    public void UpdateTo_WithCourseHavingOtherId_KeepsOwnId()
    {
        // Arrange
        Course course = CreateCourse(7);

        // Act
        course.UpdateTo(CreateChangedCourse(8));

        // Assert
        Assert.Equal(7, course.CrsId);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        Course course = CreateCourse();

        // Act
        bool result = course.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesCourseNameUnchanged()
    {
        // Arrange
        Course course = CreateCourse();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "Physics");

        // Act
        course.UpdateTo(otherData);

        // Assert
        Assert.Equal("Math", course.CourseName);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithIdAndName()
    {
        // Arrange
        Course course = CreateCourse(7);

        // Act
        object fields = course.EditFields();

        // Assert
        Course copy = Assert.IsType<Course>(fields);
        Assert.NotSame(course, copy);
        Assert.Equal(7, copy.CrsId);
        Assert.Equal("Math", copy.CourseName);
    }
}
