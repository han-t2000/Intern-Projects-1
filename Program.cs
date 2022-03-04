namespace classes;

class Program
{
    static void Main(string[] args)
    {
        var account = new BankAccount("Hanley", 550);

        Console.WriteLine(account.ToString());

        // 1 for Duitnow, 2 for IBG
        account.MakeWithdrawal(2, 500, DateTime.Now, "Paying bills of RM500 using IBG");
        Console.WriteLine(account.ToString(BankAccount.TransactionType.Withdrawal));

        account.MakeDeposit(1000, DateTime.Now, "Salary of RM1000");
        Console.WriteLine(account.ToString(BankAccount.TransactionType.Deposit));

        Console.WriteLine($"\n{account.GetAccountHistory()}\n---------------Alert Notification: Congratulations, your transaction is successful!-----------------");


        //Console.WriteLine(account);


        /*// Test that the initial balances must be positive:
        try
        {
            var invalidAccount = new BankAccount("invalid", -55);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Exception caught creating account with negative balance");
            Console.WriteLine(e.ToString());
        }

        // Test for a negative balance
        try
        {
            account.MakeWithdrawal(1, 750, DateTime.Now, "Attempt to overdraw");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Exception caught trying to overdraw");
            Console.WriteLine(e.ToString());
        }*/
    }
}
