using Poo.Models;


try
{
    BankAccount account = new BankAccount("Serge Gogo", 14800);
    account.MakeDeposit(200, DateTime.Now, "Rent payement");
    account.MakeWithdrawal(1000, DateTime.Now, "Bill payement");

    Console.WriteLine($"Acount {account.Number} was created for {account.Owner} with {account.Balance} initial balance");

    Thread.Sleep(2000);

    Console.WriteLine(account.GetAccountHistory());

}
catch(ArgumentOutOfRangeException ex)
{
    Console.Write(ex.Message );
}catch(InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}