namespace Poo.Models;

public class BankAccount
{
    private static int s_accountNumberSeed = 1234567890;
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;

            foreach ( var item in _allTransaction)
            {
                balance += item.Amount;
            }

            return balance;
        }
    }

    public BankAccount(string name, decimal initialBalance) 
    {
        Owner = name;
        
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

    private List<Transaction> _allTransaction = new List<Transaction>();


    public void MakeDeposit(decimal amout, DateTime date, string note)
    {
        if (amout <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amout), "Amount of deposit must be positive");
        }

        var deposit = new Transaction(amout, date, note);
        _allTransaction.Add(deposit);
    }

    public void MakeWithdrawal(decimal amout, DateTime date, string note) 
    {
        if (amout <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amout), "Amount of withdrawal must be positive");
        }

        if (Balance - amout <= 0 )
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }

        var withdrawal = new Transaction(-amout, date, note);
        _allTransaction.Add(withdrawal);
    }

    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;

        report.AppendLine("Date\t\t\tAmount\tBalance\tNote");

        foreach (var item in _allTransaction)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToString()}\t{item.Amount}\t{balance}\t{item.Note}");
        }

        return report.ToString();
    }


}