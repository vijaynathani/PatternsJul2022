using System;
using System.Collections.Generic;

namespace LearnCS.SInvestor_CS
{
    internal class AustralianTaxBandGenerator : TaxBandGenerator
    {
        public override IEnumerable<TaxBand> CreateTaxBands()
        {
            var taxBands = new List<TaxBand>();
            taxBands.Add(new TaxBand(0.0, 6000.99, 0.0));
            taxBands.Add(new TaxBand(6001.00, 25000.99, 0.15));
            taxBands.Add(new TaxBand(25001.00, 75000.99, 0.30));
            taxBands.Add(new TaxBand(75001.00, 150000.99, 0.40));
            taxBands.Add(new TaxBand(150001.00, Double.MaxValue, 0.45));
            return taxBands;
        }
    }
}