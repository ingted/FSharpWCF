using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AOSF = AsianOptionsServiceFSharpLib;

namespace AsianOptionsServiceFSharpLibCall
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class AsianOptionsServiceFSharp : IAsianOptionsServiceFSharp
    {
        /// <summary>
        /// Calculates the price of an option with the given 
        /// statistical information. The algorithm used for calculation 
        /// is based on the Montecarlo method.
        /// </summary>
        /// <param name="initial">Intial value.</param>
        /// <param name="exercise">Excercise value.</param>
        /// <param name="up">Up value.</param>
        /// <param name="down">Down value.</param>
        /// <param name="interest">Intrest value.</param>
        /// <param name="periods">Number of periods value.</param>
        /// <param name="runs">Number of runs.</param>
        /// <returns>The calculated value for an option with the given 
        /// statistical context using the Montecarlo Method.</returns>
        public double PriceAsianOptions(double initial, double exercise, double up, double down, double interest, int periods, int runs)
        {
            string x = AOSF.Class1.X();
            double[] pricePath = new double[periods + 1];

            // Risk-neutral probabilities
            double piup = (interest - down) / (up - down);
            double pidown = 1 - piup;

            double temp = 0.0;

            Random rand = new Random();
            double priceAverage = 0.0;
            double callPayOff = 0.0;

            for (int index = 0; index < runs; index++)
            {
                // Generate Path
                double sumPricePath = initial;

                for (int i = 1; i <= periods; i++)
                {
                    pricePath[0] = initial;
                    double rn = rand.NextDouble();

                    if (rn > pidown)
                    {
                        pricePath[i] = pricePath[i - 1] * up;
                    }
                    else
                    {
                        pricePath[i] = pricePath[i - 1] * down;
                    }

                    sumPricePath += pricePath[i];
                }

                priceAverage = sumPricePath / (periods + 1);
                callPayOff = Math.Max(priceAverage - exercise, 0);

                temp += callPayOff;
            }

            return (temp / Math.Pow(interest, periods)) / runs;
        }

    }
}
