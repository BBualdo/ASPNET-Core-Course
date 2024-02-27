namespace BankingAppExercise
{
  public class BankAccount
  {
    public int AccountNumber { get; set; }
    public string AccountHolderName { get; set; }
    public int CurrentBalance { get; set; }

    public BankAccount(int accountNumber, string accountHolderName, int currentBalance)
    {
      AccountNumber = accountNumber;
      AccountHolderName = accountHolderName;
      CurrentBalance = currentBalance;
    }
  }
}
