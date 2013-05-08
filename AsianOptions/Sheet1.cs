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

namespace AsianOptions
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using AsianOptions.AsianOptionsService;
    using Excel = Microsoft.Office.Interop.Excel;
    using Microsoft.Hpc.Scheduler.Session;
    using Microsoft.Hpc.Scheduler.Properties;
    using System.ServiceModel;
    using System.Net.Security;

    public partial class Sheet1
    {
        private static Excel.Range rngUp, rngDown, rngInitial, rngExercise, rngInterest, rngPeriods, rngRuns, rngAsianCallValue,rngHeadNode;

        private void Sheet1_Startup(object sender, System.EventArgs e)
        {
            rngUp = this.Range["B2", this.missing];
            rngDown = this.Range["B3", this.missing];
            rngInterest = this.Range["B4", this.missing];
            rngInitial = this.Range["B5", this.missing];
            rngPeriods = this.Range["B6", this.missing];
            rngExercise = this.Range["B7", this.missing];
            rngRuns = this.Range["B8", this.missing];
            rngAsianCallValue = this.Range["B9", this.missing];
            rngHeadNode = this.Range["B10", this.missing];
        }

        private void Sheet1_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void Run_Click(object sender, EventArgs e)
        {
            double initial = (double)rngInitial.Value2;
            double exercise = (double)rngInitial.Value2;
            double up = (double)rngUp.Value2;
            double down = (double)rngDown.Value2;
            double interest = (double)rngInterest.Value2;
            int periods = Convert.ToInt32(rngPeriods.Value2);
            int runs = Convert.ToInt32(rngRuns.Value2);

            double sumPrice = 0.0;
            double sumSquarePrice = 0.0;
            double min = double.MaxValue;
            double max = double.MinValue;
            double stdDev = 0.0;
            double stdErr = 0.0;

            // Run for a number of iterations
            string[] cols = { "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" };

            AutoResetEvent finishedEvt = new AutoResetEvent(false);
            int count = 0;

            SessionStartInfo info = new SessionStartInfo((string) rngHeadNode.Value2, "AsianOptionsService4");
            Stopwatch timer = null;

            // Set interface mode so that when creating a session, the program will pop up a credential
            // dialog for the user to enter the password
            Session.SetInterfaceMode(false, IntPtr.Zero);
            using (Session session = Session.CreateSession(info))
            {
                NetTcpBinding binding = new NetTcpBinding();
                // Disable encryption
                binding.Security.Transport.ProtectionLevel = ProtectionLevel.None; 
                using (AsianOptionsClient client = new AsianOptionsClient(binding, session.EndpointReference))
                {
                    timer = Stopwatch.StartNew();

                    // Set time out to MaxValue so that we'll not have timeout exceptions
                    client.InnerChannel.OperationTimeout = new TimeSpan(1, 0, 0);

                    foreach (string col in cols)
                    {
                        for (int i = 2; i <= 11; i++)
                        {
                            client.BeginPriceAsianOptions(
                                initial,
                                exercise,
                                up,
                                down,
                                interest,
                                periods,
                                runs,
                                (IAsyncResult result) =>
                                {
                                    double price = client.EndPriceAsianOptions(result);

                                    // Populate the cell: Cell Id is stored in result.AsyncState
                                    this.Range[(string)result.AsyncState, missing].Value2 = price;

                                    Interlocked.Increment(ref count);

                                    min = Math.Min(min, price);
                                    max = Math.Max(max, price);

                                    sumPrice += price;
                                    sumSquarePrice += price * price;
                                    stdDev = Math.Sqrt(sumSquarePrice - (sumPrice * sumPrice) / count) / ((count == 1) ? 1 : count - 1);
                                    stdErr = stdDev / Math.Sqrt(count);

                                    if (count == cols.Length * 10)
                                    {
                                        finishedEvt.Set();
                                    }
                                },
                                string.Format("{0}{1}", col, i));
                        }
                    }
                    finishedEvt.WaitOne();
                }
            }

            timer.Stop();

            this.Range["D13", missing].Value2 = sumPrice / count;
            this.Range["D14", missing].Value2 = min;
            this.Range["D15", missing].Value2 = max;
            this.Range["D16", missing].Value2 = stdDev;
            this.Range["D17", missing].Value2 = stdErr;
            this.Range["D18", missing].Value2 = timer.Elapsed.TotalMilliseconds / 1000.0;
        }


        private void Clear_Click(object sender, EventArgs e)
        {
            this.Range["D2", "M11"].Clear();
            this.Range["D13", "D18"].Clear();
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Run.Click += new System.EventHandler(this.Run_Click);
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            this.LocalRun.Change += new Microsoft.Office.Interop.Excel.DocEvents_ChangeEventHandler(this.LocalRun_Change);
            this.Shutdown += new System.EventHandler(this.Sheet1_Shutdown);
            this.Startup += new System.EventHandler(this.Sheet1_Startup);

        }

        private void LocalRun_Change(Microsoft.Office.Interop.Excel.Range Target)
        {

        }
    }
}