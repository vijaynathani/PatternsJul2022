using System;
using System.Collections.Generic;

namespace LearnCS.SInvestor_CS
{
    internal class NewZealandTaxBandGenerator : TaxBandGenerator
    {
        public override IEnumerable<TaxBand> CreateTaxBands()
        {
            var taxBands = new List<TaxBand>();
            taxBands.Add(new TaxBand(0.0, 19500.99, 0.195));
            taxBands.Add(new TaxBand(19501.00, 60000.99, 0.33));
            taxBands.Add(new TaxBand(60001.00, Double.MaxValue, 0.39));
            return taxBands;
        }
    }
}