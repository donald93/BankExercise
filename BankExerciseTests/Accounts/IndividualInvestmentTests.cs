using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankExerciseTests.Accounts
{
  [TestFixture]
  public class IndividualInvestmentTests
  {
    private readonly string testOwner = "TestOwner";
    private readonly decimal testBalance = 20m;
    private readonly decimal oneThousand = 1000m;

    [Test]
    public void Withdraw_cannot_exceed_1000()
    {
      var account = new TestAccount(testOwner, testBalance);

      Assert.Throws<ArgumentException>(() => account.Withdraw(oneThousand));
    }
  }
}
