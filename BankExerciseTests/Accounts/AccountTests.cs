using BankExercise.Accounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankExerciseTests
{
  [TestFixture]
  public class AccountTests
  {
    private readonly string testOwner = "TestOwner";
    private readonly decimal testBalance = 20m;
    private readonly decimal negativeOne = -1;
    private readonly decimal positiveOne = 1;

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void Constructor_throws_exception_when_owner_is_null_or_empty(string owner)
    {
      Assert.Throws<ArgumentNullException>(() => new TestAccount(owner));
    }

    [Test]
    public void Constructor_throws_exception_when_startingBalance_is_negative()
    {
      Assert.Throws<ArgumentOutOfRangeException>(() => new TestAccount(testOwner, negativeOne));
    }

    [Test]
    public void Constructor_set_balance_and_owner()
    {
      var account = new TestAccount(testOwner, testBalance);

      Assert.That(account.accountOwner, Is.EqualTo(testOwner));
      Assert.That(account.balance, Is.EqualTo(testBalance));
    }

    [Test]
    public void Deposit_cannot_be_negative()
    {
      var account = new TestAccount(testOwner);

      Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(negativeOne));
    }

    [Test]
    public void Deposit_adds_to_balance()
    {
      var account = new TestAccount(testOwner, testBalance);

      account.Deposit(positiveOne);

      Assert.That(account.balance, Is.EqualTo(testBalance + positiveOne));
    }

    [Test]
    public void Withdraw_cannot_be_negative()
    {
      var account = new TestAccount(testOwner);

      Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(negativeOne));
    }

    [Test]
    public void Withdraw_cannot_exceed_current_balance()
    {
      var account = new TestAccount(testOwner, testBalance);
      var overBalance = testBalance + positiveOne;

      Assert.Throws<ArgumentException>(() => account.Withdraw(overBalance));
    }

    [Test]
    public void Withdraw_subtracts_from_balance()
    {
      var account = new TestAccount(testOwner, testBalance);

      account.Withdraw(positiveOne);

      Assert.That(account.balance, Is.EqualTo(testBalance - positiveOne));
    }

    [Test]
    public void Transfer_cannot_be_negative()
    {
      var accountToTransferFrom = new TestAccount(testOwner);
      var accountToTransferTo = new TestAccount(testOwner);

      Assert.Throws<ArgumentOutOfRangeException>(() => accountToTransferFrom.Transfer(negativeOne, accountToTransferTo));
    }

    [Test]
    public void Transfer_cannot_exceed_current_balance()
    {
      var accountToTransferFrom = new TestAccount(testOwner);
      var accountToTransferTo = new TestAccount(testOwner);

      Assert.Throws<ArgumentException>(() => accountToTransferFrom.Transfer(positiveOne, accountToTransferTo));
    }

    [Test]
    public void Transfer_subtracts_from_account_and_adds_to_second_account()
    {
      var accountToTransferFrom = new TestAccount(testOwner, testBalance);
      var accountToTransferTo = new TestAccount(testOwner);

      accountToTransferFrom.Transfer(positiveOne, accountToTransferTo);

      Assert.That(accountToTransferFrom.balance, Is.EqualTo(testBalance - positiveOne));
      Assert.That(accountToTransferTo.balance, Is.EqualTo(positiveOne));
    }

  }
}
