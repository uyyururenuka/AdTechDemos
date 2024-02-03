using System.Net.NetworkInformation;

namespace SimpleBank.Business
{
    public class AccountManager
    {
        private List<Account> accounts = new List<Account>();

        private ITransactionLogger logger = null;
        public AccountManager()
        {
            Account account1 = new Account { AccountNo = 111, AccountType = "SAVINGS", Balance = 1000, Pin = 1234 };
            accounts.Add(account1);
            Account account2 = new Account { AccountNo = 222, AccountType = "SAVINGS", Balance = 1000, Pin = 6754 };
            accounts.Add(account2);
            Account account3 = new Account { AccountNo = 333, AccountType = "SAVINGS", Balance = 1000, Pin = 4536 };
            accounts.Add(account3);
            Account account4 = new Account { AccountNo = 444, AccountType = "SAVINGS", Balance = 1000, Pin = 2564 };
            accounts.Add(account4);
            Account account5 = new Account { AccountNo = 555, AccountType = "SAVINGS", Balance = 1000, Pin = 2323 };
            accounts.Add(account5);
        }
        public AccountManager(ITransactionLogger logger):this()
        {
           this.logger = logger;

        }
        public Account Deposit(int accNo, int amount)
        {
            
            Account accountToDeposit = IsAccountExist(accNo);

            //minimum 1000rs to be deposited
            if (amount < 1000)
            {
                throw new InvalidAmountException("Minimum deposited amount is 100rs");
            }

            //if it is success, shouls increase the balance

            accountToDeposit.Balance += amount;

            // save the below details into file
            //01/02/2024,Deposit,111,2000
            //TransactionLogger logger = new TransactionLogger();
            logger.Log($"{DateTime.Now},Deposit,{accNo},{amount}");

            return accountToDeposit;
        }

        private Account IsAccountExist(int accNo)
        {
            // account must exist
            Account accountToDeposit = accounts.Find(a => a.AccountNo == accNo);
            if (accountToDeposit == null)
            {
                // thorw exp
                throw new AccountNotExistException($"Account {accNo} not exist");
            }

            return accountToDeposit;
        }

        public Account Withdraw(int accNo, int amount,int pin)
        {
            //business rules

            //acc must be exist
            Account accountToDeposit = IsAccountExist(accNo);
            
            //sufficient balance
            if (accountToDeposit.Balance < amount)
            {
                throw new InsuffcientBalanceException("Less balance");
            }
            //valid pin
            if(accountToDeposit.Pin != pin)
            {
                throw new InvalidPinException("wrong pin");
            }
            //update/reduce the balance
            accountToDeposit.Balance -= amount;

            // save the below details into file
            //01/02/2024,Deposit,111,2000
            //ITransactionLogger logger = new TransactionLogger();
            logger.Log($"{DateTime.Now},Withdraw,{accNo},{amount}");

            return accountToDeposit;


        }
        public Account GetAccount(int accountNo)
        {
            return accounts.Find(a => a.AccountNo == accountNo);
        }

        public void Transfer(int fromAcc, int toAcc, int amount, int fromAccPin)
        {
            // fromAcc must exist
            Account fromAccount = IsAccountExist(fromAcc);
            // toacc must exist
            Account toAccount = IsAccountExist(toAcc);
            // fromAccPin must match
            if (fromAccount.Pin != fromAccPin)
            {
                throw new InvalidPinException("Invalid pin of from acc");
            }
            // sufficcient balance in fromAcc
            if (fromAccount.Balance < amount)
            {
                throw new InsuffcientBalanceException("Insufficient Valance in From Account");
            }
            // minimum amount to transfer 1000
            if (amount < 1000)
            {
                throw new InvalidAmountException("min amnt to transfer is 1000rs");
            }

            // fromacc balance should decrease
            fromAccount.Balance -= amount;
            // toAcc balance should increase
            toAccount.Balance += amount;

            logger.Log($"{DateTime.Now},Transfer,{fromAcc} to {toAcc},{amount}");

        }



    }
}