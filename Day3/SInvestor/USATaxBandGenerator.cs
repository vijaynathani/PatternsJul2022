using System;
using System.Collections.Generic;

namespace LearnCS.SInvestor_CS
{
    internal class UsaTaxBandGenerator : TaxBandGenerator
    {
        public override IEnumerable<TaxBand> CreateTaxBands()
        {
            var taxBands = new List<TaxBand>();
            taxBands.Add(new TaxBand(0.0, 7550.99, 0.10));
            taxBands.Add(new TaxBand(7551.00, 30650.99, 0.15));
            taxBands.Add(new TaxBand(30651.00, 74200.99, 0.25));
            taxBands.Add(new TaxBand(74201.00, 154800.99, 0.28));
            taxBands.Add(new TaxBand(154801.00, 336550.99, 0.33));
            taxBands.Add(new TaxBand(336551.00, Double.MaxValue, 0.35));
            return taxBands;
        }
    }
}