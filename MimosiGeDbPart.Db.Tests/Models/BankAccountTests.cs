using BackendCarcass.Domain;
using MimosiGeDbPart.Db.Models;
using Moq;
using Xunit;

namespace MimosiGeDbPart.Db.Tests.Models;

public sealed class BankAccountTests
{
    private static BankAccount CreateBankAccount(int baId = 2)
    {
        return new BankAccount
        {
            BaId = baId,
            BankName = "Old Bank",
            BankCode = "BAGAGE22",
            AccountNumber = "GE00BG0000000000000001",
            DesperateDebt = false
        };
    }

    private static BankAccount CreateChangedBankAccount(int baId = 2)
    {
        return new BankAccount
        {
            BaId = baId,
            BankName = "New Bank",
            BankCode = "TBCBGE22",
            AccountNumber = "GE00TB0000000000000002",
            DesperateDebt = true
        };
    }

    [Fact]
    public void Id_Get_ReturnsBaId()
    {
        // Arrange
        BankAccount bankAccount = CreateBankAccount(2);

        // Act
        int id = bankAccount.Id;

        // Assert
        Assert.Equal(2, id);
    }

    [Fact]
    public void Id_Set_SetsBaId()
    {
        // Arrange
        BankAccount bankAccount = CreateBankAccount(2);

        // Act
        bankAccount.Id = 6;

        // Assert
        Assert.Equal(6, bankAccount.BaId);
    }

    [Fact]
    public void Key_Get_ReturnsBankCode()
    {
        // Arrange
        BankAccount bankAccount = CreateBankAccount();

        // Act
        string? key = bankAccount.Key;

        // Assert
        Assert.Equal("BAGAGE22", key);
    }

    [Fact]
    public void Name_Get_ReturnsBankName()
    {
        // Arrange
        BankAccount bankAccount = CreateBankAccount();

        // Act
        string name = bankAccount.Name;

        // Assert
        Assert.Equal("Old Bank", name);
    }

    [Fact]
    public void ParentId_Always_ReturnsNull()
    {
        // Arrange
        BankAccount bankAccount = CreateBankAccount();

        // Act
        int? parentId = bankAccount.ParentId;

        // Assert
        Assert.Null(parentId);
    }

    [Fact]
    public void UpdateTo_WithBankAccount_ReturnsTrue()
    {
        // Arrange
        BankAccount bankAccount = CreateBankAccount();

        // Act
        bool result = bankAccount.UpdateTo(CreateChangedBankAccount());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateTo_WithBankAccount_CopiesEditableFields()
    {
        // Arrange
        BankAccount bankAccount = CreateBankAccount();

        // Act
        bankAccount.UpdateTo(CreateChangedBankAccount());

        // Assert
        Assert.Equal("New Bank", bankAccount.BankName);
        Assert.Equal("TBCBGE22", bankAccount.BankCode);
        Assert.Equal("GE00TB0000000000000002", bankAccount.AccountNumber);
        Assert.True(bankAccount.DesperateDebt);
    }

    [Fact]
    public void UpdateTo_WithBankAccountHavingOtherId_KeepsOwnId()
    {
        // Arrange
        BankAccount bankAccount = CreateBankAccount(2);

        // Act
        bankAccount.UpdateTo(CreateChangedBankAccount(9));

        // Assert
        Assert.Equal(2, bankAccount.BaId);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_ReturnsFalse()
    {
        // Arrange
        BankAccount bankAccount = CreateBankAccount();

        // Act
        bool result = bankAccount.UpdateTo(Mock.Of<IDataType>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTo_WithOtherDataType_LeavesFieldsUnchanged()
    {
        // Arrange
        BankAccount bankAccount = CreateBankAccount();
        IDataType otherData = Mock.Of<IDataType>(d => d.Key == "TBCBGE22" && d.Name == "New Bank");

        // Act
        bankAccount.UpdateTo(otherData);

        // Assert
        Assert.Equal("Old Bank", bankAccount.BankName);
        Assert.Equal("BAGAGE22", bankAccount.BankCode);
        Assert.Equal("GE00BG0000000000000001", bankAccount.AccountNumber);
        Assert.False(bankAccount.DesperateDebt);
    }

    [Fact]
    public void EditFields_Always_ReturnsCopyWithEditableFields()
    {
        // Arrange
        BankAccount bankAccount = CreateChangedBankAccount(2);

        // Act
        object fields = bankAccount.EditFields();

        // Assert
        BankAccount copy = Assert.IsType<BankAccount>(fields);
        Assert.NotSame(bankAccount, copy);
        Assert.Equal(2, copy.BaId);
        Assert.Equal("New Bank", copy.BankName);
        Assert.Equal("TBCBGE22", copy.BankCode);
        Assert.Equal("GE00TB0000000000000002", copy.AccountNumber);
        Assert.True(copy.DesperateDebt);
    }
}
