using Assignment2.BankAccountModels;
using Assignment2.BankAccountServices;
using Assignment2.Helpers;
using Assignment2.Models;
using Assignment2.Models.Menus;

namespace Assignment2.Views
{
    /// <summary>
    /// Console view for Bank Menu.
    /// </summary>
    internal class ConsoleBankMenu
    {
        /// <summary>
        /// Displays Bank Menu.
        /// </summary>
        /// <param name="bankServices">Object of BankServices</param>
        public static void ShowBankMenu(BankServices bankServices)
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();

                Console.WriteLine(@"----- Bank Menu -----
1.Create Account
2.View Account Details
3.Deposit Amount
4.Withdraw Amount
5.Back");

                BankMenu choice = (BankMenu)InputReader.ReadInt("\nEnter your choice : ", "Choice", 1, 6, 3, -1);
                if ((int)choice == -1)
                {
                    Console.ReadKey();
                    choice = BankMenu.Back;
                }

                switch (choice)
                {
                    case BankMenu.CreateAccount:
                        Console.WriteLine(@"--- Create Account ---
1. Savings Account
2. Checking Account");

                        BankAccountTypeMenu accountTypeChoice = (BankAccountTypeMenu)InputReader.ReadInt("Select Account Type : ", "Choice", 1, 3, 3, -1);
                        if ((int)accountTypeChoice == -1)
                        {
                            Console.ReadKey();
                            break;
                        }

                        string name = InputReader.ReadString("Enter Account Holder Name : ", "Account Holder Name", 30, 3, "@@@");
                        if (name == "@@@")
                        {
                            Console.ReadKey();
                            break;
                        }

                        if (accountTypeChoice == BankAccountTypeMenu.SavingsAccount)
                        {
                            decimal initialDeposit = InputReader.ReadDecimal($"Enter Initial Deposit : ", "Initial Deposit", 1, 1000000000, 3, -1);
                            if (initialDeposit == -1)
                            {
                                Console.ReadKey();
                                break;
                            }

                            SavingsAccount savingsAccount = new SavingsAccount
                            {
                                AccountHolder = name,
                                AccountBalance = initialDeposit,
                            };

                            if (initialDeposit < savingsAccount.MinimumBalance)
                            {
                                InputReader.Error($"Initial deposit must be at least ${savingsAccount.MinimumBalance} for a Savings Account.");
                                Console.ReadKey();
                                break;
                            }

                            bankServices.CreateAccount(savingsAccount);
                            InputReader.Success($"\nSavings Account Created Successfully!\nAccount Number : {savingsAccount.AccountNumber}\nAccount Balance : ${savingsAccount.AccountBalance}");
                            Console.ReadKey();
                        }
                        else if (accountTypeChoice == BankAccountTypeMenu.CheckingAccount)
                        {
                            decimal initialDeposit = InputReader.ReadDecimal("Enter Initial Deposit : ", "Initial Deposit", 0, 1000000000, 3, -1);
                            if (initialDeposit == -1)
                            {
                                Console.ReadKey();
                                break;
                            }

                            CheckingAccount checkingAccount = new CheckingAccount
                            {
                                AccountHolder = name,
                                AccountBalance = initialDeposit,
                            };

                            bankServices.CreateAccount(checkingAccount);
                            InputReader.Success($"\nChecking Account Created Successfully!\nAccount Number : {checkingAccount.AccountNumber}\nAccount Balance : ${checkingAccount.AccountBalance}");
                            Console.ReadKey();
                        }
                        else
                        {
                            InputReader.Error("\nInvalid Account Type.");
                            Console.ReadKey();
                        }

                        break;

                    case BankMenu.ViewAccountDetails:
                        Console.Write("\nEnter Account Number : ");
                        string viewAccNum = Console.ReadLine() ?? string.Empty;
                        BankAccount? accountToView = bankServices.GetAccount(viewAccNum);
                        if (accountToView == null)
                        {
                            InputReader.Error("Account not found.");
                            Console.ReadKey();
                            break;
                        }

                        string accType = accountToView is SavingsAccount ? "Savings Account" : "Checking Account";
                        Console.WriteLine($"\n--- Account Details ---" +
                            $"\nAccount Number  : {accountToView.AccountNumber}" +
                            $"\nAccount Holder  : {accountToView.AccountHolder}" +
                            $"\nAccount Type    : {accType}" +
                            $"\nAccount Balance : ${accountToView.AccountBalance}");
                        Console.ReadKey();
                        break;

                    case BankMenu.DepositAmount:
                        Console.Write("\nEnter Account Number : ");
                        string depAccNum = Console.ReadLine() ?? string.Empty;
                        BankAccount? depAccount = bankServices.GetAccount(depAccNum);
                        if (depAccount == null)
                        {
                            InputReader.Error("Account not found.");
                            Console.ReadKey();
                            break;
                        }

                        decimal depAmount = InputReader.ReadDecimal("Enter amount to Deposit : ", "Amount", 1, 1000000000, 3, -1);
                        if (depAmount == -1)
                        {
                            Console.ReadKey();
                            break;
                        }

                        if (bankServices.Deposit(depAccount, depAmount))
                        {
                            InputReader.Success($"\nAmount Deposited Successfully!\nCurrent Balance : ${depAccount.AccountBalance}");
                        }
                        else
                        {
                            InputReader.Error("Deposit failed. Please enter a valid positive amount.");
                        }

                        Console.ReadKey();
                        break;

                    case BankMenu.WithdrawAmount:
                        Console.Write("\nEnter Account Number : ");
                        string withAccNum = Console.ReadLine() ?? string.Empty;
                        BankAccount? withAccount = bankServices.GetAccount(withAccNum);
                        if (withAccount == null)
                        {
                            InputReader.Error("Account not found.");
                            Console.ReadKey();
                            break;
                        }

                        decimal withAmount = InputReader.ReadDecimal("Enter amount to Withdraw : ", "Amount", 1, 1000000000, 3, -1);
                        if (withAmount == -1)
                        {
                            Console.ReadKey();
                            break;
                        }

                        if (bankServices.Withdraw(withAccount, withAmount))
                        {
                            InputReader.Success($"\nAmount Withdrawn Successfully!\nCurrent Balance : ${withAccount.AccountBalance}");
                        }
                        else
                        {
                            if (withAccount is SavingsAccount savings && (withAccount.AccountBalance - withAmount) < savings.MinimumBalance)
                            {
                                InputReader.Error($"Withdrawal failed! Savings account requires maintaining a minimum balance of ${savings.MinimumBalance}.");
                            }
                            else
                            {
                                InputReader.Error("Withdrawal failed! Insufficient balance.");
                            }
                        }

                        Console.ReadKey();
                        break;

                    case BankMenu.Back:
                        back = true;
                        break;

                    default:
                        InputReader.Error("\nInvalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
