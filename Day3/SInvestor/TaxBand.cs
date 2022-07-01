namespace LearnCS.SInvestor_CS
{
    public class TaxBand
    {
        private const double ZeroValue = 0.0;
        private readonly double lowerLimitAmount;
        private readonly double upperLimitAmount;
        private readonly double taxRate;

        public TaxBand(double lowerLimitAmount,
                       double upperLimitAmount,
                       double taxRate)
        {
            this.lowerLimitAmount = lowerLimitAmount;
            this.upperLimitAmount = upperLimitAmount;
            this.taxRate = taxRate;
        }

        public double CalculateTaxPortion(double income)
        {
            if (EqualToOrLessThan(income, lowerLimitAmount))
                return ZeroValue;
            else if (FallWithinTaxBand(income))
                return (income - lowerLimitAmount)*taxRate;
            else if (EqualToOrGreaterThan(income, upperLimitAmount))
                return (upperLimitAmount - lowerLimitAmount)*taxRate;
            else
                return ZeroValue;
        }

        private bool FallWithinTaxBand(double income)
        {
            return EqualToOrGreaterThan(income, lowerLimitAmount)
                   && EqualToOrLessThan(income, upperLimitAmount);
        }

        private bool EqualToOrGreaterThan(double income,
                                          double bandValue)
        {
            return income >= bandValue;
        }

        private bool EqualToOrLessThan(double income, double bandValue)
        {
            return income <= bandValue;
        }

        public double getTaxRate()
        {
            return taxRate;
        }

        public double getLowerLimitAmount()
        {
            return lowerLimitAmount;
        }

        public double getUpperLimitAmount()
        {
            return upperLimitAmount;
        }
    }
}