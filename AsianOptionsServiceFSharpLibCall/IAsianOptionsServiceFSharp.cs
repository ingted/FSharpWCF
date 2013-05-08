using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AsianOptionsServiceFSharpLibCall
{
    /// <summary>
    /// Interface for the service that calculates the Price of an option on the Asian market.
    /// </summary>
    [ServiceContract]
    public interface IAsianOptionsServiceFSharp
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
        [OperationContract]
        double PriceAsianOptions(double initial, double exercise, double up, double down, double interest, int periods, int runs);
    }
}
