using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Poo.Models;

public class BankAccount
{
    private static int s_accountNumberSeed = 1234567890;
    private readonly decimal _minimumBalance;
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

    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
    {
       
    }

    public BankAccount(string name, decimal initialBalance, decimal minimalBalance)
    {
        Owner = name;

        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;

        _minimumBalance = minimalBalance;

        if (initialBalance > 0)
        {
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }
       
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

        Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amout < _minimumBalance);
        Transaction? withDrawal = new(-amout, date, note);

        if ( overdraftTransaction != null)
        {
            _allTransaction.Add(overdraftTransaction);
        }

        //if (Balance - amout < _minimumBalance)
        //{
        //    throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        //}

        //var withdrawal = new Transaction(-amout, date, note);
        //_allTransaction.Add(withdrawal);
    }

    protected virtual Transaction? CheckWithdrawalLimit(bool isOverDrawn)
    {
        if ( isOverDrawn)
        {
            throw new ArgumentOutOfRangeException("Not suficient funds for this withdrawal");
        }
        else
        {
            return default;
        }
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

    public virtual void PerformMonthEndTransaction() { }


}