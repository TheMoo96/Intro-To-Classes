using System;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Moo", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance");
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend payed me back");
            Console.WriteLine(account.Balance);
            Console.WriteLine(account.GetAccountHistory());

            //Test that the initial balance must be positive.
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("Exception caught creating account with negative balance.");
                //Console.WriteLine(e.ToString());
            }

            //Test for a negative balance
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                //Console.WriteLine(e.ToString());
            }
            finally
            { }
        }
    }
}
