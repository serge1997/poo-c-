using Poo.Models;


try
{
    BankAccount account = new BankAccount("Serge Gogo", 14800);
    account.MakeDeposit(200, DateTime.Now, "Rent payement");
    account.MakeWithdrawal(1000, DateTime.Now, "Bill payement");

    LineOfCreditAccount credit = new("Paulo", 0, 2000);
    credit.MakeWithdrawal(100m, DateTime.Now, "Take out monthly advance");

    GiftCardAccount accountGifted = new GiftCardAccount("Andressa Silva", 22000, 8000);
    accountGifted.PerformMonthEndTransaction();


    Console.WriteLine($"Acount {account.Number} was created for {account.Owner} with {account.Balance} initial balance");

    Console.WriteLine($"Acount {accountGifted.Number} was created for {accountGifted.Owner} with {accountGifted.Balance} initial balance");

    Thread.Sleep(2000);

    Console.WriteLine(account.GetAccountHistory());
    Console.WriteLine(accountGifted.GetAccountHistory());

}
catch(ArgumentOutOfRangeException ex)
{
    Console.Write(ex.Message );
}catch(InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}