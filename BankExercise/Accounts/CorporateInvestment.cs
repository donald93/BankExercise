using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankExercise.Accounts
{
  public class CorporateInvestment : Account
  {
    public CorporateInvestment(string accountOwner, decimal startingBalance = 0) : base(accountOwner, startingBalance)
    {
    }
  }
}
