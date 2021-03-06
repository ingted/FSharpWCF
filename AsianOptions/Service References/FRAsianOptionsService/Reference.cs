﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18047
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsianOptions.FRAsianOptionsService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FRAsianOptionsService.IAsianOptions")]
    public interface IAsianOptions {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAsianOptions/PriceAsianOptions", ReplyAction="http://tempuri.org/IAsianOptions/PriceAsianOptionsResponse")]
        AsianOptions.FRAsianOptionsService.PriceAsianOptionsResponse PriceAsianOptions(AsianOptions.FRAsianOptionsService.PriceAsianOptionsRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PriceAsianOptions", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class PriceAsianOptionsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public double initial;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public double exercise;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public double up;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public double down;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        public double interest;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=5)]
        public int periods;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=6)]
        public int runs;
        
        public PriceAsianOptionsRequest() {
        }
        
        public PriceAsianOptionsRequest(double initial, double exercise, double up, double down, double interest, int periods, int runs) {
            this.initial = initial;
            this.exercise = exercise;
            this.up = up;
            this.down = down;
            this.interest = interest;
            this.periods = periods;
            this.runs = runs;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PriceAsianOptionsResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class PriceAsianOptionsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public double PriceAsianOptionsResult;
        
        public PriceAsianOptionsResponse() {
        }
        
        public PriceAsianOptionsResponse(double PriceAsianOptionsResult) {
            this.PriceAsianOptionsResult = PriceAsianOptionsResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAsianOptionsChannel : AsianOptions.FRAsianOptionsService.IAsianOptions, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AsianOptionsClient : System.ServiceModel.ClientBase<AsianOptions.FRAsianOptionsService.IAsianOptions>, AsianOptions.FRAsianOptionsService.IAsianOptions {
        
        public AsianOptionsClient() {
        }
        
        public AsianOptionsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AsianOptionsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AsianOptionsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AsianOptionsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AsianOptions.FRAsianOptionsService.PriceAsianOptionsResponse PriceAsianOptions(AsianOptions.FRAsianOptionsService.PriceAsianOptionsRequest request) {
            return base.Channel.PriceAsianOptions(request);
        }
    }
}
