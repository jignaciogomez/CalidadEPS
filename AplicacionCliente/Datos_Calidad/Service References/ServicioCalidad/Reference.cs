﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos_Calidad.ServicioCalidad {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Dato", Namespace="http://schemas.datacontract.org/2004/07/Wcfdatos")]
    [System.SerializableAttribute()]
    public partial class Dato : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string codigo_categoriaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string codigo_epsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int demoninadorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string linkfuenteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nombre_EPSField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nombre_categoriaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nomespecifiqueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nomfuenteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nomidentificadorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nomservicioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nomunidadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int numeradorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int resultadoField;
        
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
        public string codigo_categoria {
            get {
                return this.codigo_categoriaField;
            }
            set {
                if ((object.ReferenceEquals(this.codigo_categoriaField, value) != true)) {
                    this.codigo_categoriaField = value;
                    this.RaisePropertyChanged("codigo_categoria");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string codigo_eps {
            get {
                return this.codigo_epsField;
            }
            set {
                if ((object.ReferenceEquals(this.codigo_epsField, value) != true)) {
                    this.codigo_epsField = value;
                    this.RaisePropertyChanged("codigo_eps");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int demoninador {
            get {
                return this.demoninadorField;
            }
            set {
                if ((this.demoninadorField.Equals(value) != true)) {
                    this.demoninadorField = value;
                    this.RaisePropertyChanged("demoninador");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string linkfuente {
            get {
                return this.linkfuenteField;
            }
            set {
                if ((object.ReferenceEquals(this.linkfuenteField, value) != true)) {
                    this.linkfuenteField = value;
                    this.RaisePropertyChanged("linkfuente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombre_EPS {
            get {
                return this.nombre_EPSField;
            }
            set {
                if ((object.ReferenceEquals(this.nombre_EPSField, value) != true)) {
                    this.nombre_EPSField = value;
                    this.RaisePropertyChanged("nombre_EPS");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombre_categoria {
            get {
                return this.nombre_categoriaField;
            }
            set {
                if ((object.ReferenceEquals(this.nombre_categoriaField, value) != true)) {
                    this.nombre_categoriaField = value;
                    this.RaisePropertyChanged("nombre_categoria");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nomespecifique {
            get {
                return this.nomespecifiqueField;
            }
            set {
                if ((object.ReferenceEquals(this.nomespecifiqueField, value) != true)) {
                    this.nomespecifiqueField = value;
                    this.RaisePropertyChanged("nomespecifique");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nomfuente {
            get {
                return this.nomfuenteField;
            }
            set {
                if ((object.ReferenceEquals(this.nomfuenteField, value) != true)) {
                    this.nomfuenteField = value;
                    this.RaisePropertyChanged("nomfuente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nomidentificador {
            get {
                return this.nomidentificadorField;
            }
            set {
                if ((object.ReferenceEquals(this.nomidentificadorField, value) != true)) {
                    this.nomidentificadorField = value;
                    this.RaisePropertyChanged("nomidentificador");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nomservicio {
            get {
                return this.nomservicioField;
            }
            set {
                if ((object.ReferenceEquals(this.nomservicioField, value) != true)) {
                    this.nomservicioField = value;
                    this.RaisePropertyChanged("nomservicio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nomunidad {
            get {
                return this.nomunidadField;
            }
            set {
                if ((object.ReferenceEquals(this.nomunidadField, value) != true)) {
                    this.nomunidadField = value;
                    this.RaisePropertyChanged("nomunidad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int numerador {
            get {
                return this.numeradorField;
            }
            set {
                if ((this.numeradorField.Equals(value) != true)) {
                    this.numeradorField = value;
                    this.RaisePropertyChanged("numerador");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int resultado {
            get {
                return this.resultadoField;
            }
            set {
                if ((this.resultadoField.Equals(value) != true)) {
                    this.resultadoField = value;
                    this.RaisePropertyChanged("resultado");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CargarDatos.CargaDatos", Namespace="http://schemas.datacontract.org/2004/07/Wcfdatos")]
    [System.SerializableAttribute()]
    public partial class CargarDatosCargaDatos : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string codigoField;
        
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
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string codigo {
            get {
                return this.codigoField;
            }
            set {
                if ((object.ReferenceEquals(this.codigoField, value) != true)) {
                    this.codigoField = value;
                    this.RaisePropertyChanged("codigo");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CargaBarra", Namespace="http://schemas.datacontract.org/2004/07/Wcfdatos")]
    [System.SerializableAttribute()]
    public partial class CargaBarra : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomservicioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nombre_categoriaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int resultadoField;
        
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
        public string Nomservicio {
            get {
                return this.NomservicioField;
            }
            set {
                if ((object.ReferenceEquals(this.NomservicioField, value) != true)) {
                    this.NomservicioField = value;
                    this.RaisePropertyChanged("Nomservicio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombre_categoria {
            get {
                return this.nombre_categoriaField;
            }
            set {
                if ((object.ReferenceEquals(this.nombre_categoriaField, value) != true)) {
                    this.nombre_categoriaField = value;
                    this.RaisePropertyChanged("nombre_categoria");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int resultado {
            get {
                return this.resultadoField;
            }
            set {
                if ((this.resultadoField.Equals(value) != true)) {
                    this.resultadoField = value;
                    this.RaisePropertyChanged("resultado");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioCalidad.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ObtenerDatos", ReplyAction="http://tempuri.org/IService1/ObtenerDatosResponse")]
        Datos_Calidad.ServicioCalidad.Dato[] ObtenerDatos(string CodigoEPS);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ObtenerDatos", ReplyAction="http://tempuri.org/IService1/ObtenerDatosResponse")]
        System.Threading.Tasks.Task<Datos_Calidad.ServicioCalidad.Dato[]> ObtenerDatosAsync(string CodigoEPS);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CargarObjetos", ReplyAction="http://tempuri.org/IService1/CargarObjetosResponse")]
        Datos_Calidad.ServicioCalidad.CargarDatosCargaDatos[] CargarObjetos(string Opcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CargarObjetos", ReplyAction="http://tempuri.org/IService1/CargarObjetosResponse")]
        System.Threading.Tasks.Task<Datos_Calidad.ServicioCalidad.CargarDatosCargaDatos[]> CargarObjetosAsync(string Opcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CargueEncuesta", ReplyAction="http://tempuri.org/IService1/CargueEncuestaResponse")]
        int CargueEncuesta(int pregunta, int respuesta, string Codigo_EPS);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CargueEncuesta", ReplyAction="http://tempuri.org/IService1/CargueEncuestaResponse")]
        System.Threading.Tasks.Task<int> CargueEncuestaAsync(int pregunta, int respuesta, string Codigo_EPS);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Carga_Barra", ReplyAction="http://tempuri.org/IService1/Carga_BarraResponse")]
        Datos_Calidad.ServicioCalidad.CargaBarra[] Carga_Barra(string EPS);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Carga_Barra", ReplyAction="http://tempuri.org/IService1/Carga_BarraResponse")]
        System.Threading.Tasks.Task<Datos_Calidad.ServicioCalidad.CargaBarra[]> Carga_BarraAsync(string EPS);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Carga_Torta", ReplyAction="http://tempuri.org/IService1/Carga_TortaResponse")]
        Datos_Calidad.ServicioCalidad.CargaBarra[] Carga_Torta(string EPS);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Carga_Torta", ReplyAction="http://tempuri.org/IService1/Carga_TortaResponse")]
        System.Threading.Tasks.Task<Datos_Calidad.ServicioCalidad.CargaBarra[]> Carga_TortaAsync(string EPS);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Datos_Calidad.ServicioCalidad.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Datos_Calidad.ServicioCalidad.IService1>, Datos_Calidad.ServicioCalidad.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Datos_Calidad.ServicioCalidad.Dato[] ObtenerDatos(string CodigoEPS) {
            return base.Channel.ObtenerDatos(CodigoEPS);
        }
        
        public System.Threading.Tasks.Task<Datos_Calidad.ServicioCalidad.Dato[]> ObtenerDatosAsync(string CodigoEPS) {
            return base.Channel.ObtenerDatosAsync(CodigoEPS);
        }
        
        public Datos_Calidad.ServicioCalidad.CargarDatosCargaDatos[] CargarObjetos(string Opcion) {
            return base.Channel.CargarObjetos(Opcion);
        }
        
        public System.Threading.Tasks.Task<Datos_Calidad.ServicioCalidad.CargarDatosCargaDatos[]> CargarObjetosAsync(string Opcion) {
            return base.Channel.CargarObjetosAsync(Opcion);
        }
        
        public int CargueEncuesta(int pregunta, int respuesta, string Codigo_EPS) {
            return base.Channel.CargueEncuesta(pregunta, respuesta, Codigo_EPS);
        }
        
        public System.Threading.Tasks.Task<int> CargueEncuestaAsync(int pregunta, int respuesta, string Codigo_EPS) {
            return base.Channel.CargueEncuestaAsync(pregunta, respuesta, Codigo_EPS);
        }
        
        public Datos_Calidad.ServicioCalidad.CargaBarra[] Carga_Barra(string EPS) {
            return base.Channel.Carga_Barra(EPS);
        }
        
        public System.Threading.Tasks.Task<Datos_Calidad.ServicioCalidad.CargaBarra[]> Carga_BarraAsync(string EPS) {
            return base.Channel.Carga_BarraAsync(EPS);
        }
        
        public Datos_Calidad.ServicioCalidad.CargaBarra[] Carga_Torta(string EPS) {
            return base.Channel.Carga_Torta(EPS);
        }
        
        public System.Threading.Tasks.Task<Datos_Calidad.ServicioCalidad.CargaBarra[]> Carga_TortaAsync(string EPS) {
            return base.Channel.Carga_TortaAsync(EPS);
        }
    }
}
