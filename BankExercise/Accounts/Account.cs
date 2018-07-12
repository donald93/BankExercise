using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankExercise.Accounts
{
  public abstract class Account
  {
    public string accountOwner { get; }
    public decimal balance { get; private set; }

    public Account(string accountOwner, decimal startingBalance = 0m)
    {
      if(string.IsNullOrWhiteSpace(accountOwner))
      {
        throw new ArgumentNullException($"Parameter {nameof(accountOwner)} with value {accountOwner} is not a valid owner name");
      }

      if(startingBalance < 0m)
      {
        throw new ArgumentOutOfRangeException($"Cannot create an account with less than 0 balance");
      }
      
      this.accountOwner = accountOwner;
      this.balance = startingBalance;
    }

    public void Deposit(decimal amount)
    {
      if(amount < 0)
      {
        throw new ArgumentOutOfRangeException("Can only deposit postive amounts");
      }

      balance += amount;
    }

    public virtual void Withdraw(decimal amount)
    {
      if (amount < 0)
      {
        throw new ArgumentOutOfRangeException("Can only withdraw postive amounts");
      }

      if(amount > balance)
      {
        throw new ArgumentException("Can't withdraw more than current balance");
      }

      balance -= amount;
    }

    public void Transfer(decimal amount, Account accountToReceiveFunds)
    {
      if (amount < 0)
      {
        throw new ArgumentOutOfRangeException("Can only transfer postive amounts");
      }

      if (amount > balance)
      {
        throw new ArgumentException("Can't transfer more than current balance");
      }

      balance -= amount;
      accountToReceiveFunds.Deposit(amount);
    }
  }
}
