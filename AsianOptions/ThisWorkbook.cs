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
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using AsianOptions.AsianOptionsService;
    using Microsoft.Hpc.Scheduler;
    using Microsoft.Hpc.Scheduler.Properties;
    using Microsoft.Hpc.Scheduler.Session;


    public partial class ThisWorkbook
    {
        private void ThisWorkbook_Startup(object sender, System.EventArgs e)
        {
            Globals.Sheet1.Run.Enabled = true;
            Globals.Sheet1.Clear.Enabled = true;
        }

        private void ThisWorkbook_Shutdown(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Shutdown += new System.EventHandler(this.ThisWorkbook_Shutdown);
            this.Startup += new System.EventHandler(this.ThisWorkbook_Startup);
        }
    }
}