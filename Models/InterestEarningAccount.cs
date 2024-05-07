namespace Poo.Models;

public class InterestEarningAccount : BankAccount
{

    public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
    {

    }


    public override void PerformMonthEndTransaction()
    {
        if (Balance > 500m)
        {
            decimal interest = Balance * 0.20m;
            MakeDeposit(interest, DateTime.Now, "Apply monthly interest");
        }
    }
}