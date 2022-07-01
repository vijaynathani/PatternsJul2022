using System;
using System.Collections.Generic;

namespace LearnCS.SInvestor_CS
{
    public class IncomeTaxEngine
    {
        private readonly IEnumerable<TaxBand> taxBands;

        public IncomeTaxEngine() : this("")
        {
            //IncomeTaxEngine("");
        }

        public IncomeTaxEngine(String cultureInfo)
        {
            taxBands = TaxBandGenerator.CreateInstance(cultureInfo)
                .CreateTaxBands();
        }

        public double CalculateTaxLiability(double income)
        {
            double taxLiability = 0;
            foreach (var taxBand in taxBands)
                taxLiability += taxBand.CalculateTaxPortion(income);
            return taxLiability;
        }

        public double CalculateTaxRate(double income)
        {
            TaxBand selectedBand = null;
            foreach (var t in taxBands)
                if (income >= t.getLowerLimitAmount()
                    && income <= t.getUpperLimitAmount())
                    selectedBand = t;
            return selectedBand.getTaxRate();
        }
    }
}