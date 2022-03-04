namespace classes;

public class BankAccount
{
    public string Number { get; }
    public string Owner { get; set; }

    private List<Transaction> allTransactions = new List<Transaction>();

    private static int accountNumberSeed = 1234567890;

    public double Balance
    {
        get
        {
            double balance = 0;

            foreach (var item in allTransactions)
            {
                balance += item.Amount;
            }

            return balance;
        }
    }

    public BankAccount(string name, double initialBalance)
    {
        this.Number = accountNumberSeed.ToString();
        accountNumberSeed++;

        this.Owner = name;
        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

    public void MakeDeposit(double amount, DateTime dateTime, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }

        var deposit = new Transaction(amount, dateTime, note);
        allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(int type, double amount, DateTime dateTime, string note)
    {

        ValidateInput(amount);

        double fees = 0.1;

        if (type == 1)
        {
            amount += ((amount / 100) * fees);
        }

        var withdrawal = new Transaction(-amount, dateTime, note);
        allTransactions.Add(withdrawal);
    }

    private void ValidateInput(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }

        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
    }

    public override string ToString()
    {
        return $"A new account of {Number} was created for {Owner} with initial balance of RM{Balance}.\n";
    }

    public string ToString(TransactionType transactionType)
    {
        switch (transactionType)
        {
            case TransactionType.Withdrawal:
                return $"Your new account balance after {nameof(TransactionType.Withdrawal)} is: RM" + Balance + ".";
            case TransactionType.Deposit:
                return $"Your new account balance after {nameof(TransactionType.Deposit)} is: RM" + Balance + ".";
            default: throw new ArgumentException("Transaction type undefined.");
        }
    }

    public enum TransactionType
    {
        Withdrawal,
        Deposit
    }

    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        double balance = 0;
        report.AppendLine("------------------------------------------------------------------\nDate/Time\t\tAmount\tBalance\tNote\n------------------------------------------------------------------");

        foreach (var item in allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.DateTime.ToString("g")}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        File.WriteAllText(@"C:\Temp\TransactionLog.txt", Convert.ToString(report));
        return report.ToString();

    }
}
