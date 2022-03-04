using System;

namespace classes
{
    public class Transaction
    {
        public double Amount { get; }
        public DateTime DateTime { get; }
        public string Notes { get; }

        public Transaction(double amount, DateTime dateTime, string note)
        {
            this.Amount = amount;
            this.DateTime = dateTime;
            this.Notes = note;
        }
    }
}