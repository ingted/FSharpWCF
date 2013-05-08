﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsianOptions4.AsianOptionsService4 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AsianOptionsService4.IAsianOptions4")]
    public interface IAsianOptions4 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAsianOptions4/PriceAsianOptions", ReplyAction="http://tempuri.org/IAsianOptions4/PriceAsianOptionsResponse")]
        double PriceAsianOptions(double initial, double exercise, double up, double down, double interest, int periods, int runs);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IAsianOptions4/PriceAsianOptions", ReplyAction="http://tempuri.org/IAsianOptions4/PriceAsianOptionsResponse")]
        System.IAsyncResult BeginPriceAsianOptions(double initial, double exercise, double up, double down, double interest, int periods, int runs, System.AsyncCallback callback, object asyncState);
        
        double EndPriceAsianOptions(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAsianOptions4Channel : AsianOptions4.AsianOptionsService4.IAsianOptions4, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PriceAsianOptionsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public PriceAsianOptionsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public double Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AsianOptions4Client : System.ServiceModel.ClientBase<AsianOptions4.AsianOptionsService4.IAsianOptions4>, AsianOptions4.AsianOptionsService4.IAsianOptions4 {
        
        private BeginOperationDelegate onBeginPriceAsianOptionsDelegate;
        
        private EndOperationDelegate onEndPriceAsianOptionsDelegate;
        
        private System.Threading.SendOrPostCallback onPriceAsianOptionsCompletedDelegate;
        
        public AsianOptions4Client() {
        }
        
        public AsianOptions4Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AsianOptions4Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AsianOptions4Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AsianOptions4Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<PriceAsianOptionsCompletedEventArgs> PriceAsianOptionsCompleted;
        
        public double PriceAsianOptions(double initial, double exercise, double up, double down, double interest, int periods, int runs) {
            return base.Channel.PriceAsianOptions(initial, exercise, up, down, interest, periods, runs);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginPriceAsianOptions(double initial, double exercise, double up, double down, double interest, int periods, int runs, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginPriceAsianOptions(initial, exercise, up, down, interest, periods, runs, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public double EndPriceAsianOptions(System.IAsyncResult result) {
            return base.Channel.EndPriceAsianOptions(result);
        }
        
        private System.IAsyncResult OnBeginPriceAsianOptions(object[] inValues, System.AsyncCallback callback, object asyncState) {
            double initial = ((double)(inValues[0]));
            double exercise = ((double)(inValues[1]));
            double up = ((double)(inValues[2]));
            double down = ((double)(inValues[3]));
            double interest = ((double)(inValues[4]));
            int periods = ((int)(inValues[5]));
            int runs = ((int)(inValues[6]));
            return this.BeginPriceAsianOptions(initial, exercise, up, down, interest, periods, runs, callback, asyncState);
        }
        
        private object[] OnEndPriceAsianOptions(System.IAsyncResult result) {
            double retVal = this.EndPriceAsianOptions(result);
            return new object[] {
                    retVal};
        }
        
        private void OnPriceAsianOptionsCompleted(object state) {
            if ((this.PriceAsianOptionsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.PriceAsianOptionsCompleted(this, new PriceAsianOptionsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void PriceAsianOptionsAsync(double initial, double exercise, double up, double down, double interest, int periods, int runs) {
            this.PriceAsianOptionsAsync(initial, exercise, up, down, interest, periods, runs, null);
        }
        
        public void PriceAsianOptionsAsync(double initial, double exercise, double up, double down, double interest, int periods, int runs, object userState) {
            if ((this.onBeginPriceAsianOptionsDelegate == null)) {
                this.onBeginPriceAsianOptionsDelegate = new BeginOperationDelegate(this.OnBeginPriceAsianOptions);
            }
            if ((this.onEndPriceAsianOptionsDelegate == null)) {
                this.onEndPriceAsianOptionsDelegate = new EndOperationDelegate(this.OnEndPriceAsianOptions);
            }
            if ((this.onPriceAsianOptionsCompletedDelegate == null)) {
                this.onPriceAsianOptionsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPriceAsianOptionsCompleted);
            }
            base.InvokeAsync(this.onBeginPriceAsianOptionsDelegate, new object[] {
                        initial,
                        exercise,
                        up,
                        down,
                        interest,
                        periods,
                        runs}, this.onEndPriceAsianOptionsDelegate, this.onPriceAsianOptionsCompletedDelegate, userState);
        }
    }
}
