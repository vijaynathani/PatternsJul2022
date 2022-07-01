using System;
using System.Collections.Generic;

namespace LearnCS.SInvestor_CS
{
    public abstract class TaxBandGenerator
    {
        public static TaxBandGenerator CreateInstance()
        {
            return CreateInstance("");
        }

        public static TaxBandGenerator CreateInstance(
            String cultureInfo)
        {
            if (cultureInfo.Equals("en-NZ"))
                return new NewZealandTaxBandGenerator();
            else if (cultureInfo.Equals("en-AU"))
                return new AustralianTaxBandGenerator();
            else if (cultureInfo.Equals("en-US"))
                return new UsaTaxBandGenerator();
            else
                return new NullTaxBandGenerator();
        }

        public abstract IEnumerable<TaxBand> CreateTaxBands();
    }
}