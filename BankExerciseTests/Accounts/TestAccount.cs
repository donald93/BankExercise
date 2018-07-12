using BankExercise.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankExerciseTests
{
  public class TestAccount : Account
  {
    public TestAccount(string accountOwner, decimal startingBalance = 0) : base(accountOwner, startingBalance)
    {
    }
  }
}
