﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XyzWeb.Legado {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Legado.ILegado")]
    public interface ILegado {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILegado/BuscarComponentes", ReplyAction="http://tempuri.org/ILegado/BuscarComponentesResponse")]
        string[] BuscarComponentes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILegado/BuscarComponentes", ReplyAction="http://tempuri.org/ILegado/BuscarComponentesResponse")]
        System.Threading.Tasks.Task<string[]> BuscarComponentesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILegado/NomeUniversidade", ReplyAction="http://tempuri.org/ILegado/NomeUniversidadeResponse")]
        string NomeUniversidade();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILegado/NomeUniversidade", ReplyAction="http://tempuri.org/ILegado/NomeUniversidadeResponse")]
        System.Threading.Tasks.Task<string> NomeUniversidadeAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILegadoChannel : XyzWeb.Legado.ILegado, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LegadoClient : System.ServiceModel.ClientBase<XyzWeb.Legado.ILegado>, XyzWeb.Legado.ILegado {
        
        public LegadoClient() {
        }
        
        public LegadoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LegadoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LegadoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LegadoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] BuscarComponentes() {
            return base.Channel.BuscarComponentes();
        }
        
        public System.Threading.Tasks.Task<string[]> BuscarComponentesAsync() {
            return base.Channel.BuscarComponentesAsync();
        }
        
        public string NomeUniversidade() {
            return base.Channel.NomeUniversidade();
        }
        
        public System.Threading.Tasks.Task<string> NomeUniversidadeAsync() {
            return base.Channel.NomeUniversidadeAsync();
        }
    }
}
