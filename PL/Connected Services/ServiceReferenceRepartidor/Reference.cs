﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL.ServiceReferenceRepartidor {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceRepartidor.IRepartidor")]
    public interface IRepartidor {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidor/DoWork", ReplyAction="http://tempuri.org/IRepartidor/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidor/DoWork", ReplyAction="http://tempuri.org/IRepartidor/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidor/Add", ReplyAction="http://tempuri.org/IRepartidor/AddResponse")]
        bool Add(ML.Repartidor repartidor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidor/Add", ReplyAction="http://tempuri.org/IRepartidor/AddResponse")]
        System.Threading.Tasks.Task<bool> AddAsync(ML.Repartidor repartidor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidor/Update", ReplyAction="http://tempuri.org/IRepartidor/UpdateResponse")]
        bool Update(ML.Repartidor repartidor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidor/Update", ReplyAction="http://tempuri.org/IRepartidor/UpdateResponse")]
        System.Threading.Tasks.Task<bool> UpdateAsync(ML.Repartidor repartidor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidor/Delete", ReplyAction="http://tempuri.org/IRepartidor/DeleteResponse")]
        bool Delete(int idRepartidor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidor/Delete", ReplyAction="http://tempuri.org/IRepartidor/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(int idRepartidor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidor/GetAll", ReplyAction="http://tempuri.org/IRepartidor/GetAllResponse")]
        ML.Repartidor[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidor/GetAll", ReplyAction="http://tempuri.org/IRepartidor/GetAllResponse")]
        System.Threading.Tasks.Task<ML.Repartidor[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidor/GetById", ReplyAction="http://tempuri.org/IRepartidor/GetByIdResponse")]
        ML.Repartidor GetById(int idRepartidor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidor/GetById", ReplyAction="http://tempuri.org/IRepartidor/GetByIdResponse")]
        System.Threading.Tasks.Task<ML.Repartidor> GetByIdAsync(int idRepartidor);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRepartidorChannel : PL.ServiceReferenceRepartidor.IRepartidor, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RepartidorClient : System.ServiceModel.ClientBase<PL.ServiceReferenceRepartidor.IRepartidor>, PL.ServiceReferenceRepartidor.IRepartidor {
        
        public RepartidorClient() {
        }
        
        public RepartidorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RepartidorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RepartidorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RepartidorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public bool Add(ML.Repartidor repartidor) {
            return base.Channel.Add(repartidor);
        }
        
        public System.Threading.Tasks.Task<bool> AddAsync(ML.Repartidor repartidor) {
            return base.Channel.AddAsync(repartidor);
        }
        
        public bool Update(ML.Repartidor repartidor) {
            return base.Channel.Update(repartidor);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateAsync(ML.Repartidor repartidor) {
            return base.Channel.UpdateAsync(repartidor);
        }
        
        public bool Delete(int idRepartidor) {
            return base.Channel.Delete(idRepartidor);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAsync(int idRepartidor) {
            return base.Channel.DeleteAsync(idRepartidor);
        }
        
        public ML.Repartidor[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<ML.Repartidor[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public ML.Repartidor GetById(int idRepartidor) {
            return base.Channel.GetById(idRepartidor);
        }
        
        public System.Threading.Tasks.Task<ML.Repartidor> GetByIdAsync(int idRepartidor) {
            return base.Channel.GetByIdAsync(idRepartidor);
        }
    }
}