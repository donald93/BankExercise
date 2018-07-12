using BankExercise.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankExercise
{
  public class Bank
  {
    private IList<Account> accounts;
    public string Name { get; }

    public Bank(string name, IList<Account> accounts = null)
    {
      if(string.IsNullOrWhiteSpace(name))
      {
        throw new ArgumentNullException($"Parameter {nameof(name)} with value {name} is not a valid name for a bank");
      }

      this.Name = name;
      this.accounts = accounts ?? new List<Account>();
    }

    public IEnumerable<Account> FindAccountsByOwner(string owner)
    {
      return accounts.Where(a => a.accountOwner == owner);
    }

    public void OpenCheckingAccount(string owner, decimal startingBalance = 0)
    {
      accounts.Add(new Checking(owner, startingBalance));
    }

    public void OpenCorporateInvestmentAccount(string owner, decimal startingBalance = 0)
    {
      accounts.Add(new CorporateInvestment(owner, startingBalance));
    }
    public void OpenIndividualInvestmentAccount(string owner, decimal startingBalance = 0)
    {
      accounts.Add(new IndividualInvestment(owner, startingBalance));
    }

  }
}
