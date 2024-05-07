
namespace Poo.Models;

public class GiftCardAccount : BankAccount
{

    private readonly decimal _montlyDeposit = 0m;
    public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance) => _montlyDeposit = monthlyDeposit;


    public override void PerformMonthEndTransaction()
    {
        if (_montlyDeposit != 0)
        {
            MakeDeposit(_montlyDeposit, DateTime.Now, "Add montlhy deposit");
        }
    }

}
