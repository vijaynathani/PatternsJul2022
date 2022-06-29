using System;
//Improve the code
class Payment {
    const string FOC = "FOC"; //free of charge.
    const string TT = "TT"; //paid by telegraphic transfer.
    const string CHEQUE = "Cheque"; //paid by cheque.
    const string CREDIT_CARD = "CreditCard"; //paid by credit card.
    const string CASH = "Cash"; //paid by cash.
    //type of payment. Must be one of the above constant.
    string paymentType;

    DateTime paymentDate; //if FOC, the date the fee is waived.
    int actualPayment; //if FOC, it is 0.
    int discount; //if FOC, the amount that is waived.
    string bankName; //if it is by TT, cheque or credit card.
    string chequeNumber; //if it is by cheque.

    //if it is by credit card.
    string creditCardType;
    string creditCardHolderName;
    string creditCardNumber;
    DateTime creditCardExpiryDate;

    int getNominalPayment() {
        return actualPayment+discount;
    }

    string getBankName() {
        if (paymentType.Equals(TT) || paymentType.Equals(CHEQUE) ||
            paymentType.Equals(CREDIT_CARD)) {
            return bankName;
        }
        else
            throw new Exception(
                "bank name is undefined for this payment type");
    }
}
