﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DSA_Assignment1_Sit1.BarcodeServ {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.webservicex.net/", ConfigurationName="BarcodeServ.BarCodeSoap")]
    public interface BarCodeSoap {
        
        // CODEGEN: Parameter 'GenerateBarCodeResult' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webservicex.net/GenerateBarCode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        DSA_Assignment1_Sit1.BarcodeServ.GenerateBarCodeResponse GenerateBarCode(DSA_Assignment1_Sit1.BarcodeServ.GenerateBarCodeRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.webservicex.net/")]
    public partial class BarCodeData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int heightField;
        
        private int widthField;
        
        private int angleField;
        
        private int ratioField;
        
        private int moduleField;
        
        private int leftField;
        
        private int topField;
        
        private bool checkSumField;
        
        private string fontNameField;
        
        private string barColorField;
        
        private string bGColorField;
        
        private float fontSizeField;
        
        private BarcodeOption barcodeOptionField;
        
        private BarcodeType barcodeTypeField;
        
        private CheckSumMethod checkSumMethodField;
        
        private ShowTextPosition showTextPositionField;
        
        private ImageFormats barCodeImageFormatField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int Height {
            get {
                return this.heightField;
            }
            set {
                this.heightField = value;
                this.RaisePropertyChanged("Height");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int Width {
            get {
                return this.widthField;
            }
            set {
                this.widthField = value;
                this.RaisePropertyChanged("Width");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int Angle {
            get {
                return this.angleField;
            }
            set {
                this.angleField = value;
                this.RaisePropertyChanged("Angle");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int Ratio {
            get {
                return this.ratioField;
            }
            set {
                this.ratioField = value;
                this.RaisePropertyChanged("Ratio");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int Module {
            get {
                return this.moduleField;
            }
            set {
                this.moduleField = value;
                this.RaisePropertyChanged("Module");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int Left {
            get {
                return this.leftField;
            }
            set {
                this.leftField = value;
                this.RaisePropertyChanged("Left");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int Top {
            get {
                return this.topField;
            }
            set {
                this.topField = value;
                this.RaisePropertyChanged("Top");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public bool CheckSum {
            get {
                return this.checkSumField;
            }
            set {
                this.checkSumField = value;
                this.RaisePropertyChanged("CheckSum");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string FontName {
            get {
                return this.fontNameField;
            }
            set {
                this.fontNameField = value;
                this.RaisePropertyChanged("FontName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string BarColor {
            get {
                return this.barColorField;
            }
            set {
                this.barColorField = value;
                this.RaisePropertyChanged("BarColor");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string BGColor {
            get {
                return this.bGColorField;
            }
            set {
                this.bGColorField = value;
                this.RaisePropertyChanged("BGColor");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public float FontSize {
            get {
                return this.fontSizeField;
            }
            set {
                this.fontSizeField = value;
                this.RaisePropertyChanged("FontSize");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public BarcodeOption barcodeOption {
            get {
                return this.barcodeOptionField;
            }
            set {
                this.barcodeOptionField = value;
                this.RaisePropertyChanged("barcodeOption");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public BarcodeType barcodeType {
            get {
                return this.barcodeTypeField;
            }
            set {
                this.barcodeTypeField = value;
                this.RaisePropertyChanged("barcodeType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public CheckSumMethod checkSumMethod {
            get {
                return this.checkSumMethodField;
            }
            set {
                this.checkSumMethodField = value;
                this.RaisePropertyChanged("checkSumMethod");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public ShowTextPosition showTextPosition {
            get {
                return this.showTextPositionField;
            }
            set {
                this.showTextPositionField = value;
                this.RaisePropertyChanged("showTextPosition");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public ImageFormats BarCodeImageFormat {
            get {
                return this.barCodeImageFormatField;
            }
            set {
                this.barCodeImageFormatField = value;
                this.RaisePropertyChanged("BarCodeImageFormat");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.webservicex.net/")]
    public enum BarcodeOption {
        
        /// <remarks/>
        None,
        
        /// <remarks/>
        Code,
        
        /// <remarks/>
        Typ,
        
        /// <remarks/>
        Both,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.webservicex.net/")]
    public enum BarcodeType {
        
        /// <remarks/>
        Code_2_5_interleaved,
        
        /// <remarks/>
        Code_2_5_industrial,
        
        /// <remarks/>
        Code_2_5_matrix,
        
        /// <remarks/>
        Code39,
        
        /// <remarks/>
        Code39Extended,
        
        /// <remarks/>
        Code128A,
        
        /// <remarks/>
        Code128B,
        
        /// <remarks/>
        Code128C,
        
        /// <remarks/>
        Code93,
        
        /// <remarks/>
        Code93Extended,
        
        /// <remarks/>
        CodeMSI,
        
        /// <remarks/>
        CodePostNet,
        
        /// <remarks/>
        CodeCodabar,
        
        /// <remarks/>
        CodeEAN8,
        
        /// <remarks/>
        CodeEAN13,
        
        /// <remarks/>
        CodeUPC_A,
        
        /// <remarks/>
        CodeUPC_E0,
        
        /// <remarks/>
        CodeUPC_E1,
        
        /// <remarks/>
        CodeUPC_Supp2,
        
        /// <remarks/>
        CodeUPC_Supp5,
        
        /// <remarks/>
        CodeEAN128A,
        
        /// <remarks/>
        CodeEAN128B,
        
        /// <remarks/>
        CodeEAN128C,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.webservicex.net/")]
    public enum CheckSumMethod {
        
        /// <remarks/>
        None,
        
        /// <remarks/>
        Modulo10,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.webservicex.net/")]
    public enum ShowTextPosition {
        
        /// <remarks/>
        TopLeft,
        
        /// <remarks/>
        TopRight,
        
        /// <remarks/>
        TopCenter,
        
        /// <remarks/>
        BottomLeft,
        
        /// <remarks/>
        BottomRight,
        
        /// <remarks/>
        BottomCenter,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.webservicex.net/")]
    public enum ImageFormats {
        
        /// <remarks/>
        BMP,
        
        /// <remarks/>
        EMF,
        
        /// <remarks/>
        EXIF,
        
        /// <remarks/>
        GIF,
        
        /// <remarks/>
        ICON,
        
        /// <remarks/>
        JPEG,
        
        /// <remarks/>
        MemoryBMP,
        
        /// <remarks/>
        PNG,
        
        /// <remarks/>
        TIFF,
        
        /// <remarks/>
        WMF,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GenerateBarCode", WrapperNamespace="http://www.webservicex.net/", IsWrapped=true)]
    public partial class GenerateBarCodeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.webservicex.net/", Order=0)]
        public DSA_Assignment1_Sit1.BarcodeServ.BarCodeData BarCodeParam;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.webservicex.net/", Order=1)]
        public string BarCodeText;
        
        public GenerateBarCodeRequest() {
        }
        
        public GenerateBarCodeRequest(DSA_Assignment1_Sit1.BarcodeServ.BarCodeData BarCodeParam, string BarCodeText) {
            this.BarCodeParam = BarCodeParam;
            this.BarCodeText = BarCodeText;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GenerateBarCodeResponse", WrapperNamespace="http://www.webservicex.net/", IsWrapped=true)]
    public partial class GenerateBarCodeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.webservicex.net/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] GenerateBarCodeResult;
        
        public GenerateBarCodeResponse() {
        }
        
        public GenerateBarCodeResponse(byte[] GenerateBarCodeResult) {
            this.GenerateBarCodeResult = GenerateBarCodeResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface BarCodeSoapChannel : DSA_Assignment1_Sit1.BarcodeServ.BarCodeSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BarCodeSoapClient : System.ServiceModel.ClientBase<DSA_Assignment1_Sit1.BarcodeServ.BarCodeSoap>, DSA_Assignment1_Sit1.BarcodeServ.BarCodeSoap {
        
        public BarCodeSoapClient() {
        }
        
        public BarCodeSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BarCodeSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BarCodeSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BarCodeSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DSA_Assignment1_Sit1.BarcodeServ.GenerateBarCodeResponse DSA_Assignment1_Sit1.BarcodeServ.BarCodeSoap.GenerateBarCode(DSA_Assignment1_Sit1.BarcodeServ.GenerateBarCodeRequest request) {
            return base.Channel.GenerateBarCode(request);
        }
        
        public byte[] GenerateBarCode(DSA_Assignment1_Sit1.BarcodeServ.BarCodeData BarCodeParam, string BarCodeText) {
            DSA_Assignment1_Sit1.BarcodeServ.GenerateBarCodeRequest inValue = new DSA_Assignment1_Sit1.BarcodeServ.GenerateBarCodeRequest();
            inValue.BarCodeParam = BarCodeParam;
            inValue.BarCodeText = BarCodeText;
            DSA_Assignment1_Sit1.BarcodeServ.GenerateBarCodeResponse retVal = ((DSA_Assignment1_Sit1.BarcodeServ.BarCodeSoap)(this)).GenerateBarCode(inValue);
            return retVal.GenerateBarCodeResult;
        }
    }
}
