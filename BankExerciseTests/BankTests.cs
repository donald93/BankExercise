using System;
using System.Linq;
using BankExercise;
using BankExercise.Accounts;
using NUnit.Framework;

namespace BankExerciseTests
{
  [TestFixture]
  public class BankTests
  {
    private readonly string testName = "TestBankName";
    private readonly string testOwner = "TestOwnerName";
    private readonly decimal testBalance = 20m;

    [Test]
    public void Constructor_sets_name()
    {
      var bank = new Bank(testName);

      Assert.That(bank.Name, Is.EqualTo(testName));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void Constructor_throws_exception_when_name_is_null_or_empty(string name)
    {
      Assert.Throws<ArgumentNullException>(() => new Bank(name));
    }

    [Test]
    public void Can_add_account_even_if_list_is_null_in_constructor()
    {
      var bank = new Bank(testName);
      Assert.DoesNotThrow(() => bank.OpenCheckingAccount(testOwner));
    }

    [Test]
    public void FindAccountsByOwner_returns_empty_list_when_there_are_no_accounts()
    {
      var bank = new Bank(testName);
      var accounts = bank.FindAccountsByOwner(testOwner);

      Assert.That(accounts, Is.Empty);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(3)]
    [TestCase(50)]
    public void FindAccountsByOwner_returns_all_accounts_for_owner(int numberOfAccounts)
    {
      var bank = new Bank(testName);
      for (int i = 0; i < numberOfAccounts; i++)
      {
        bank.OpenCheckingAccount(testOwner);
      }
      var accounts = bank.FindAccountsByOwner(testOwner);
      Assert.That(accounts.Count, Is.EqualTo(numberOfAccounts));
    }

    [Test]
    public void Can_create_checking_account()
    {
      var bank = new Bank(testName);

        bank.OpenCheckingAccount(testOwner);
      var accounts = bank.FindAccountsByOwner(testOwner);
     
      Assert.That(accounts.FirstOrDefault(), Is.TypeOf<Checking>());
    }

    [Test]
    public void Can_create_corporate_investment_account()
    {
      var bank = new Bank(testName);

      bank.OpenCorporateInvestmentAccount(testOwner);
      var accounts = bank.FindAccountsByOwner(testOwner);

      Assert.That(accounts.FirstOrDefault(), Is.TypeOf<CorporateInvestment>());
    }

    [Test]
    public void Can_create_individual_investment_account()
    {
      var bank = new Bank(testName);

      bank.OpenIndividualInvestmentAccount(testOwner);
      var accounts = bank.FindAccountsByOwner(testOwner);

      Assert.That(accounts.FirstOrDefault(), Is.TypeOf<IndividualInvestment>());
    }

    [Test]
    public void Can_create_account_with_balance()
    {
      var bank = new Bank(testName);

      bank.OpenIndividualInvestmentAccount(testOwner, testBalance);
      var account = bank.FindAccountsByOwner(testOwner).FirstOrDefault();

      Assert.That(account.balance, Is.EqualTo(testBalance));
    }
  }
}
