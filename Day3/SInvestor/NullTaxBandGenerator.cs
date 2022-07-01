using System;
using System.Collections.Generic;

namespace LearnCS.SInvestor_CS
{
    internal class NullTaxBandGenerator : TaxBandGenerator
    {
        public override IEnumerable<TaxBand> CreateTaxBands()
        {
            var taxBands = new List<TaxBand>();
            taxBands.Add(new TaxBand(0.0, Double.MaxValue, 0.0));
            return taxBands;
        }
    }
}