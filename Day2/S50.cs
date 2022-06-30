abstract class Account {
	private double balance;
	public double getBalance() { return balance; }
	abstract public double calcInterest();
	public double getInterestRate() { 
		//...
	}
} 
class SavingAccount : Account {
	public override double calcInterest() {
		return getBalance()*getInterestRate();
	}
} 
class ChequeAccount : Account {
	public override double calcInterest() {
		return 0;
	}
} 
class FixedAccount : Account {
	public override double calcInterest() {
		return getBalance()*(getInterestRate()+0.02);
	}
}
