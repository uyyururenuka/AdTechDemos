using SimpleBank.Business;
using System.Net.NetworkInformation;

namespace SImpleBank.Business.TestProject
{
    class MockTransactionLogger : ITransactionLogger
    {
        public void Log(string message)
        {

        }
    }

    [TestClass]
    public class AccountManagerUnitTest
    {
        
        AccountManager target = null;
        [TestInitialize]
        public void Init()
        {
            //executes before evry test case
            target = new AccountManager(new MockTransactionLogger());

        }
        [TestMethod]
        public void DepositTest_OnSuccess_SHouldIncreaseBalance()
        {
            //AAA Approach
            //A-Arrangement
            //AccountManager target = new AccountManager();
            int accno = 111;
            int amount = 2000;
            int expectedBalance = 3000;

            //A-Act
            Account acc = target.Deposit(accno, amount);

            //A-Assert
            Assert.AreEqual(expectedBalance, acc.Balance);  
        }

        [TestMethod]
        [ExpectedException(typeof(AccountNotExistException))]
        public void Deposit_AccNotExist_ThrowsExp()
        {
            //A-Arrangement
            //AccountManager target = new AccountManager();
            //int accno = 123;
            //int amount = 2000;
            //int expectedBalance = 3000;

            //A-Act
            Account acc = target.Deposit(123, 2000);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAmountException))]
        public void Deposit_MinimumAmount_ThrowsExp()
        {
            //AccountManager target = new AccountManager();
            //int accno = 111;
            //int amount = 500;
            //int expectedBalance = 3000;

            //A-Act
            Account acc = target.Deposit(111, 500);

        }
        [TestMethod]
        public void Withdraw_OnSucess_ShouldDecreaseBalance()
        {
            //AccountManager target = new AccountManager();

            //A-Arrange
            //int accno = 111;
            //int amount = 500;
            //int pin = 1234;
            //int expectedBalance = 500;

            //A-Act
            Account acc=target.Withdraw(111,500,1234);

            //A-Assert
            Assert.AreEqual(500, acc.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountNotExistException))]
        public void Withdraw_AccNotExist_ThrowsExp()
        {
            //A-Arrangement
            //AccountManager target = new AccountManager();
            //int accno = 123;
            //int amount = 2000;
            //int expectedBalance = 3000;

            //A-Act
            Account acc = target.Withdraw(112, 2000, 1234);
        }
        [TestMethod]
        [ExpectedException(typeof(InsuffcientBalanceException))]
        public void Withdraw_InsufficientBalance_ThrowsExp()
        {
            //AccountManager target = new AccountManager();
            //int accno = 111;
            //int amount = 2000;
            //int expectedBalance = 500;

            //A-Act
            Account acc = target.Withdraw(111, 2000, 1234);
        }
        [TestMethod]
        [ExpectedException (typeof(InvalidPinException))]
        public void Withdraw_InvalidPin_ThrowsExp()
        {
            Account acc = target.Withdraw(111, 500, 1334);
        }


        
        [TestMethod]
        public void TransferTest_SuccessfulTransfer_BalanceUpdated()
        {

            // Account fromAccount = new Account { AccountNo = 111, Balance = 5000, Pin = 1234 };
            // Account toAccount = new Account { AccountNo = 222, Balance = 2000, Pin = 5678 };
            //AccountManager target = new AccountManager(new MockTransactionLogger());
            Account a = target.GetAccount(222);
            target.Transfer(111, 222, 1000, 1234);

            //target.Transfer(111,222, 2000, 1234);

            Assert.AreEqual(2000, a.Balance);
            //Assert.AreEqual(3000, toAccount.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPinException))]
        public void TransferTest_InvalidPin_ThrowsExp()
        {
            Account fromAccount = new Account { AccountNo = 111, Balance = 5000, Pin = 1234 };
            Account toAccount = new Account { AccountNo = 222, Balance = 2000, Pin = 5678 };

            target.Transfer(fromAccount.AccountNo, toAccount.AccountNo, 1000, 0000);
        }

        [TestMethod]
        [ExpectedException(typeof(InsuffcientBalanceException))]
        public void TransferTest_InsufficientBalance_ThrowsExp()
        {
            //  Account fromAccount = new Account { AccountNo = 111, Balance = 500, Pin = 1234 };
            // Account toAccount = new Account { AccountNo = 222, Balance = 2000, Pin = 5678 };

            target.Transfer(111, 222, 2000, 1234);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidAmountException))]
        public void TransferTest_InvalidAmount_ThrowsExp()
        {

            Account fromAccount = new Account { AccountNo = 111, Balance = 5000, Pin = 1234 };
            Account toAccount = new Account { AccountNo = 222, Balance = 2000, Pin = 5678 };


            target.Transfer(fromAccount.AccountNo, toAccount.AccountNo, 500, fromAccount.Pin);
        }




    }
}