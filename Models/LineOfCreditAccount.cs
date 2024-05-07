namespace Poo.Models;

public class LineOfCreditAccount : BankAccount
{
    //can i have inital balance < 0
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
    {
        if (Balance < creditLimit )
        {
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");

        }
    }


    protected override Transaction? CheckWithdrawalLimit(bool isOverDrawn) =>
        isOverDrawn
        ? new Transaction(-20, DateTime.Now, "Apply over draft fee")
        : default;
    
}