// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

namespace AsianOptionsService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;

    /// <summary>
    /// Interface for the service that calculates the Price of an option on the Asian market.
    /// </summary>
    [ServiceContract]
    public interface IAsianOptions
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