using System;
abstract class Payment {
	DateTime paymentDate;
	public abstract int getNominalPayment();
}
class FreeOfCharge : Payment {
	int amountWaived;
	public override int getNominalPayment() {
		return amountWaived;
	}
}
class RealPayment : Payment {
	int actualPayment;
	int discount;
	public override int getNominalPayment() {
		return actualPayment+discount;
	}
}
class CashPayment : RealPayment {
}
class BankPayment : RealPayment {
	string bankName;
	string getBankName() {
		return bankName;
	}
}
class TelegraphicTransfer : BankPayment {
}
class ChequePayment : BankPayment {
	string chequeNumber;
}
class CreditCardPayment : BankPayment {
	string cardType;
	string cardHolderName;
	string cardNumber;
	DateTime expiryDate;
}
