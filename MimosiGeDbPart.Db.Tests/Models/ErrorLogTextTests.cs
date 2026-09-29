using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class ErrorLogTextTests
{
    private static ErrorLogText CreateErrorLogText(int id = 3)
    {
        return new ErrorLogText
        {
            EltId = id,
            Text = "შეცდომა 1"
        };
    }

    private static ErrorLogText CreateOtherErrorLogText(int id = 3)
    {
        return new ErrorLogText
        {
            EltId = id,
            Text = "შეცდომა 2"
        };
    }

    [Fact]
    public void Id_Get_ReturnsEltId()
    {
        // Arrange
        ErrorLogText errorLogText = CreateErrorLogText(3);

        // Act
        int id = errorLogText.Id;

        // Assert
        Assert.Equal(3, id);
    }

    [Fact]
    public void Id_Set_SetsEltId()
    {
        // Arrange
        ErrorLogText errorLogText = CreateErrorLogText(3);

        // Act
        errorLogText.Id = 5;

        // Assert
        Assert.Equal(5, errorLogText.EltId);
    }

    [Fact]
    public void Key_Always_ReturnsNull()
    {
        // Arrange
        ErrorLogText errorLogText = CreateErrorLogText();

        // Act
        string? key = errorLogText.Key;

        // Assert
        Assert.Null(key);
    }

    [Fact]
    public void Name_Get_ReturnsText()
    {
        // Arrange
        ErrorLogText errorLogText = CreateErrorLogText();

        // Act
        string? name = errorLogText.Name;

        // Assert
        Assert.Equal("შეცდომა 1", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        ErrorLogText errorLogText = CreateErrorLogText();

        // Act
        int? parentId = errorLogText.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithErrorLogText_ReturnsTrue()
    {
        // Arrange
        ErrorLogText errorLogText = CreateErrorLogText();

        // Act
        bool result = errorLogText.UpdateTo(CreateOtherErrorLogText());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithErrorLogText_CopiesEditableFields()
    {
        // Arrange
        ErrorLogText errorLogText = CreateErrorLogText();

        // Act
        errorLogText.UpdateTo(CreateOtherErrorLogText());

        // Assert
        Assert.Equal("შეცდომა 2", errorLogText.Text);
    }

    [Fact]
    public void UpdateTo_WithErrorLogTextHavingOtherId_KeepsOwnId()
    {
        // Arrange
        ErrorLogText errorLogText = CreateErrorLogText(3);

        // Act
        errorLogText.UpdateTo(CreateOtherErrorLogText(4));

        // Assert
        Assert.Equal(3, errorLogText.EltId);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        ErrorLogText errorLogText = CreateErrorLogText();

        // Act
        bool result = errorLogText.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        ErrorLogText errorLogText = CreateErrorLogText();
        IDataType otherData = Mock.Of<IDataType>(d => d.Name == "სხვა");

        // Act
        errorLogText.UpdateTo(otherData);

        // Assert
        Assert.Equal("შეცდომა 1", errorLogText.Text);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        ErrorLogText errorLogText = CreateErrorLogText(3);

        // Act
        object fields = errorLogText.EditFields();

        // Assert
        ErrorLogText copy = Assert.IsType<ErrorLogText>(fields);
        Assert.NotSame(errorLogText, copy);
        Assert.Equal(3, copy.EltId);
        Assert.Equal("შეცდომა 1", copy.Text);
    }
}
