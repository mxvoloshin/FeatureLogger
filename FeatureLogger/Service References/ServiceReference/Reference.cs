﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FeatureLogger.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ModificationInfo", Namespace="http://schemas.datacontract.org/2004/07/FeatureLoggerService.Entities")]
    [System.SerializableAttribute()]
    public partial class ModificationInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long FIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FeatureClassField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FeatureLogger.ServiceReference.GeometryModificationInfo GeometryInfoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ModifyTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FeatureLogger.ServiceReference.SemanticsModificationInfo[] SemanticsInfoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FeatureLogger.ServiceReference.ModifyState StateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long FID {
            get {
                return this.FIDField;
            }
            set {
                if ((this.FIDField.Equals(value) != true)) {
                    this.FIDField = value;
                    this.RaisePropertyChanged("FID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FeatureClass {
            get {
                return this.FeatureClassField;
            }
            set {
                if ((object.ReferenceEquals(this.FeatureClassField, value) != true)) {
                    this.FeatureClassField = value;
                    this.RaisePropertyChanged("FeatureClass");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FeatureLogger.ServiceReference.GeometryModificationInfo GeometryInfo {
            get {
                return this.GeometryInfoField;
            }
            set {
                if ((object.ReferenceEquals(this.GeometryInfoField, value) != true)) {
                    this.GeometryInfoField = value;
                    this.RaisePropertyChanged("GeometryInfo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ModifyTime {
            get {
                return this.ModifyTimeField;
            }
            set {
                if ((this.ModifyTimeField.Equals(value) != true)) {
                    this.ModifyTimeField = value;
                    this.RaisePropertyChanged("ModifyTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FeatureLogger.ServiceReference.SemanticsModificationInfo[] SemanticsInfo {
            get {
                return this.SemanticsInfoField;
            }
            set {
                if ((object.ReferenceEquals(this.SemanticsInfoField, value) != true)) {
                    this.SemanticsInfoField = value;
                    this.RaisePropertyChanged("SemanticsInfo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FeatureLogger.ServiceReference.ModifyState State {
            get {
                return this.StateField;
            }
            set {
                if ((this.StateField.Equals(value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GeometryModificationInfo", Namespace="http://schemas.datacontract.org/2004/07/FeatureLoggerService.Entities")]
    [System.SerializableAttribute()]
    public partial class GeometryModificationInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FeatureLogger.ServiceReference.ModificationInfo InfoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WKTGeometryField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FeatureLogger.ServiceReference.ModificationInfo Info {
            get {
                return this.InfoField;
            }
            set {
                if ((object.ReferenceEquals(this.InfoField, value) != true)) {
                    this.InfoField = value;
                    this.RaisePropertyChanged("Info");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WKTGeometry {
            get {
                return this.WKTGeometryField;
            }
            set {
                if ((object.ReferenceEquals(this.WKTGeometryField, value) != true)) {
                    this.WKTGeometryField = value;
                    this.RaisePropertyChanged("WKTGeometry");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SemanticsModificationInfo", Namespace="http://schemas.datacontract.org/2004/07/FeatureLoggerService.Entities")]
    [System.SerializableAttribute()]
    public partial class SemanticsModificationInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AttributeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FeatureLogger.ServiceReference.ModificationInfo InfoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Attribute {
            get {
                return this.AttributeField;
            }
            set {
                if ((object.ReferenceEquals(this.AttributeField, value) != true)) {
                    this.AttributeField = value;
                    this.RaisePropertyChanged("Attribute");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FeatureLogger.ServiceReference.ModificationInfo Info {
            get {
                return this.InfoField;
            }
            set {
                if ((object.ReferenceEquals(this.InfoField, value) != true)) {
                    this.InfoField = value;
                    this.RaisePropertyChanged("Info");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ModifyState", Namespace="http://schemas.datacontract.org/2004/07/FeatureLoggerService.Entities")]
    public enum ModifyState : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        None = -1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Inserted = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Modified = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Deleted = 2,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ModificationInfoDTO", Namespace="http://schemas.datacontract.org/2004/07/FeatureLoggerService.Entities")]
    [System.SerializableAttribute()]
    public partial class ModificationInfoDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FeatureLogger.ServiceReference.ModificationInfo[] InfosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TotalCountField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FeatureLogger.ServiceReference.ModificationInfo[] Infos {
            get {
                return this.InfosField;
            }
            set {
                if ((object.ReferenceEquals(this.InfosField, value) != true)) {
                    this.InfosField = value;
                    this.RaisePropertyChanged("Infos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TotalCount {
            get {
                return this.TotalCountField;
            }
            set {
                if ((this.TotalCountField.Equals(value) != true)) {
                    this.TotalCountField = value;
                    this.RaisePropertyChanged("TotalCount");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IFeatureLogService")]
    public interface IFeatureLogService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFeatureLogService/AddFeatureModifyLog", ReplyAction="http://tempuri.org/IFeatureLogService/AddFeatureModifyLogResponse")]
        bool AddFeatureModifyLog(FeatureLogger.ServiceReference.ModificationInfo modifyInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFeatureLogService/GetFeatureModifyInfos", ReplyAction="http://tempuri.org/IFeatureLogService/GetFeatureModifyInfosResponse")]
        FeatureLogger.ServiceReference.ModificationInfoDTO GetFeatureModifyInfos(long featureFid, string user, FeatureLogger.ServiceReference.ModifyState state, string featureClass, int skipCount, int takeCount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFeatureLogService/GetFeatureModifyInfosInPeriod", ReplyAction="http://tempuri.org/IFeatureLogService/GetFeatureModifyInfosInPeriodResponse")]
        FeatureLogger.ServiceReference.ModificationInfoDTO GetFeatureModifyInfosInPeriod(long featureFid, string user, FeatureLogger.ServiceReference.ModifyState state, string featureClass, System.DateTime dateFrom, System.DateTime dateTo, int skipCount, int takeCount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFeatureLogService/GetSemanticsModificationInfo", ReplyAction="http://tempuri.org/IFeatureLogService/GetSemanticsModificationInfoResponse")]
        FeatureLogger.ServiceReference.SemanticsModificationInfo[] GetSemanticsModificationInfo(long modificationInfoId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFeatureLogService/GetUsers", ReplyAction="http://tempuri.org/IFeatureLogService/GetUsersResponse")]
        string[] GetUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFeatureLogService/GetFeatureClasses", ReplyAction="http://tempuri.org/IFeatureLogService/GetFeatureClassesResponse")]
        string[] GetFeatureClasses();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFeatureLogServiceChannel : FeatureLogger.ServiceReference.IFeatureLogService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FeatureLogServiceClient : System.ServiceModel.ClientBase<FeatureLogger.ServiceReference.IFeatureLogService>, FeatureLogger.ServiceReference.IFeatureLogService {
        
        public FeatureLogServiceClient() {
        }
        
        public FeatureLogServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FeatureLogServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FeatureLogServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FeatureLogServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool AddFeatureModifyLog(FeatureLogger.ServiceReference.ModificationInfo modifyInfo) {
            return base.Channel.AddFeatureModifyLog(modifyInfo);
        }
        
        public FeatureLogger.ServiceReference.ModificationInfoDTO GetFeatureModifyInfos(long featureFid, string user, FeatureLogger.ServiceReference.ModifyState state, string featureClass, int skipCount, int takeCount) {
            return base.Channel.GetFeatureModifyInfos(featureFid, user, state, featureClass, skipCount, takeCount);
        }
        
        public FeatureLogger.ServiceReference.ModificationInfoDTO GetFeatureModifyInfosInPeriod(long featureFid, string user, FeatureLogger.ServiceReference.ModifyState state, string featureClass, System.DateTime dateFrom, System.DateTime dateTo, int skipCount, int takeCount) {
            return base.Channel.GetFeatureModifyInfosInPeriod(featureFid, user, state, featureClass, dateFrom, dateTo, skipCount, takeCount);
        }
        
        public FeatureLogger.ServiceReference.SemanticsModificationInfo[] GetSemanticsModificationInfo(long modificationInfoId) {
            return base.Channel.GetSemanticsModificationInfo(modificationInfoId);
        }
        
        public string[] GetUsers() {
            return base.Channel.GetUsers();
        }
        
        public string[] GetFeatureClasses() {
            return base.Channel.GetFeatureClasses();
        }
    }
}