abstract class Payment {
    int units;
    double rate;
    public const double TAX_RATE = 0.1;
    public abstract double getPreTaxedAmount();
    public abstract double getTaxRate();
    public double getBillableAmount() {
        return getPreTaxedAmount() * (1 + getTaxRate());
    }
    public double getNormalAmount() {
        return units * rate;
    }
}
class NormalPayment : Payment {
    public override double getPreTaxedAmount() {
        return getNormalAmount();
    }
    public override double getTaxRate() {
        return TAX_RATE;
    }
}
class PaymentForSeniorCitizen : Payment {
    public override double getPreTaxedAmount() {
        return getNormalAmount()*0.8;
    }
    public override double getTaxRate() {
        return TAX_RATE - 0.05;
    }
}
