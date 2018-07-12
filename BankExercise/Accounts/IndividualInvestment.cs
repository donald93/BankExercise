using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankExercise.Accounts
{
  public class IndividualInvestment : Account
  {
    public IndividualInvestment(string accountOwner, decimal startingBalance = 0) : base(accountOwner, startingBalance)
    {
    }

    public override void Withdraw(decimal amount)
    {
      if(amount > 1000m)
      {
        throw new ArgumentOutOfRangeException("Individual investment accounts may only withdraw up to $1,000 at a time.");
      }

      base.Withdraw(amount);
    }
  }
}
