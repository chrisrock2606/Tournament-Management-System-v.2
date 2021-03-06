﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceAccessLayer.TournamentService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Tournament", Namespace="http://schemas.datacontract.org/2004/07/Domain")]
    [System.SerializableAttribute()]
    public partial class Tournament : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GameNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServiceAccessLayer.TournamentService.Player[] PlayersInTournamentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RewardField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServiceAccessLayer.TournamentService.Round[] RoundsInTournamentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TournamentIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TournamentNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TournamentStatusField;
        
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
        public string GameName {
            get {
                return this.GameNameField;
            }
            set {
                if ((object.ReferenceEquals(this.GameNameField, value) != true)) {
                    this.GameNameField = value;
                    this.RaisePropertyChanged("GameName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
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
        public ServiceAccessLayer.TournamentService.Player[] PlayersInTournament {
            get {
                return this.PlayersInTournamentField;
            }
            set {
                if ((object.ReferenceEquals(this.PlayersInTournamentField, value) != true)) {
                    this.PlayersInTournamentField = value;
                    this.RaisePropertyChanged("PlayersInTournament");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Reward {
            get {
                return this.RewardField;
            }
            set {
                if ((object.ReferenceEquals(this.RewardField, value) != true)) {
                    this.RewardField = value;
                    this.RaisePropertyChanged("Reward");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceAccessLayer.TournamentService.Round[] RoundsInTournament {
            get {
                return this.RoundsInTournamentField;
            }
            set {
                if ((object.ReferenceEquals(this.RoundsInTournamentField, value) != true)) {
                    this.RoundsInTournamentField = value;
                    this.RaisePropertyChanged("RoundsInTournament");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TournamentId {
            get {
                return this.TournamentIdField;
            }
            set {
                if ((this.TournamentIdField.Equals(value) != true)) {
                    this.TournamentIdField = value;
                    this.RaisePropertyChanged("TournamentId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TournamentName {
            get {
                return this.TournamentNameField;
            }
            set {
                if ((object.ReferenceEquals(this.TournamentNameField, value) != true)) {
                    this.TournamentNameField = value;
                    this.RaisePropertyChanged("TournamentName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TournamentStatus {
            get {
                return this.TournamentStatusField;
            }
            set {
                if ((object.ReferenceEquals(this.TournamentStatusField, value) != true)) {
                    this.TournamentStatusField = value;
                    this.RaisePropertyChanged("TournamentStatus");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Player", Namespace="http://schemas.datacontract.org/2004/07/Domain")]
    [System.SerializableAttribute()]
    public partial class Player : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhoneNrField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PlayerIdField;
        
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
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
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
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PhoneNr {
            get {
                return this.PhoneNrField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneNrField, value) != true)) {
                    this.PhoneNrField = value;
                    this.RaisePropertyChanged("PhoneNr");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PlayerId {
            get {
                return this.PlayerIdField;
            }
            set {
                if ((this.PlayerIdField.Equals(value) != true)) {
                    this.PlayerIdField = value;
                    this.RaisePropertyChanged("PlayerId");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Round", Namespace="http://schemas.datacontract.org/2004/07/Domain")]
    [System.SerializableAttribute()]
    public partial class Round : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServiceAccessLayer.TournamentService.Match[] MatchesInRoundField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServiceAccessLayer.TournamentService.Player[] PlayersInRoundField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RoundIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoundNameField;
        
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
        public int ID {
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
        public ServiceAccessLayer.TournamentService.Match[] MatchesInRound {
            get {
                return this.MatchesInRoundField;
            }
            set {
                if ((object.ReferenceEquals(this.MatchesInRoundField, value) != true)) {
                    this.MatchesInRoundField = value;
                    this.RaisePropertyChanged("MatchesInRound");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceAccessLayer.TournamentService.Player[] PlayersInRound {
            get {
                return this.PlayersInRoundField;
            }
            set {
                if ((object.ReferenceEquals(this.PlayersInRoundField, value) != true)) {
                    this.PlayersInRoundField = value;
                    this.RaisePropertyChanged("PlayersInRound");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RoundId {
            get {
                return this.RoundIdField;
            }
            set {
                if ((this.RoundIdField.Equals(value) != true)) {
                    this.RoundIdField = value;
                    this.RaisePropertyChanged("RoundId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RoundName {
            get {
                return this.RoundNameField;
            }
            set {
                if ((object.ReferenceEquals(this.RoundNameField, value) != true)) {
                    this.RoundNameField = value;
                    this.RaisePropertyChanged("RoundName");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Match", Namespace="http://schemas.datacontract.org/2004/07/Domain")]
    [System.SerializableAttribute()]
    public partial class Match : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MatchIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServiceAccessLayer.TournamentService.Player[] PlayersInMatchField;
        
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
        public int ID {
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
        public int MatchId {
            get {
                return this.MatchIdField;
            }
            set {
                if ((this.MatchIdField.Equals(value) != true)) {
                    this.MatchIdField = value;
                    this.RaisePropertyChanged("MatchId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceAccessLayer.TournamentService.Player[] PlayersInMatch {
            get {
                return this.PlayersInMatchField;
            }
            set {
                if ((object.ReferenceEquals(this.PlayersInMatchField, value) != true)) {
                    this.PlayersInMatchField = value;
                    this.RaisePropertyChanged("PlayersInMatch");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TournamentService.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SaveTournament", ReplyAction="http://tempuri.org/IService/SaveTournamentResponse")]
        void SaveTournament(ServiceAccessLayer.TournamentService.Tournament newTournament);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SaveTournament", ReplyAction="http://tempuri.org/IService/SaveTournamentResponse")]
        System.Threading.Tasks.Task SaveTournamentAsync(ServiceAccessLayer.TournamentService.Tournament newTournament);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/TryToSavePlayerToTournament", ReplyAction="http://tempuri.org/IService/TryToSavePlayerToTournamentResponse")]
        bool TryToSavePlayerToTournament(ServiceAccessLayer.TournamentService.Player newPlayer, int tournamentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/TryToSavePlayerToTournament", ReplyAction="http://tempuri.org/IService/TryToSavePlayerToTournamentResponse")]
        System.Threading.Tasks.Task<bool> TryToSavePlayerToTournamentAsync(ServiceAccessLayer.TournamentService.Player newPlayer, int tournamentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetTournaments", ReplyAction="http://tempuri.org/IService/GetTournamentsResponse")]
        ServiceAccessLayer.TournamentService.Tournament[] GetTournaments();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetTournaments", ReplyAction="http://tempuri.org/IService/GetTournamentsResponse")]
        System.Threading.Tasks.Task<ServiceAccessLayer.TournamentService.Tournament[]> GetTournamentsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : ServiceAccessLayer.TournamentService.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<ServiceAccessLayer.TournamentService.IService>, ServiceAccessLayer.TournamentService.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void SaveTournament(ServiceAccessLayer.TournamentService.Tournament newTournament) {
            base.Channel.SaveTournament(newTournament);
        }
        
        public System.Threading.Tasks.Task SaveTournamentAsync(ServiceAccessLayer.TournamentService.Tournament newTournament) {
            return base.Channel.SaveTournamentAsync(newTournament);
        }
        
        public bool TryToSavePlayerToTournament(ServiceAccessLayer.TournamentService.Player newPlayer, int tournamentId) {
            return base.Channel.TryToSavePlayerToTournament(newPlayer, tournamentId);
        }
        
        public System.Threading.Tasks.Task<bool> TryToSavePlayerToTournamentAsync(ServiceAccessLayer.TournamentService.Player newPlayer, int tournamentId) {
            return base.Channel.TryToSavePlayerToTournamentAsync(newPlayer, tournamentId);
        }
        
        public ServiceAccessLayer.TournamentService.Tournament[] GetTournaments() {
            return base.Channel.GetTournaments();
        }
        
        public System.Threading.Tasks.Task<ServiceAccessLayer.TournamentService.Tournament[]> GetTournamentsAsync() {
            return base.Channel.GetTournamentsAsync();
        }
    }
}
