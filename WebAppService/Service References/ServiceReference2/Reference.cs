﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppService.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.MyWebServiceSoap")]
    public interface MyWebServiceSoap {
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 HelloWorldResult 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        WebAppService.ServiceReference2.HelloWorldResponse HelloWorld(WebAppService.ServiceReference2.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<WebAppService.ServiceReference2.HelloWorldResponse> HelloWorldAsync(WebAppService.ServiceReference2.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Multiplier", ReplyAction="*")]
        int Multiplier(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Multiplier", ReplyAction="*")]
        System.Threading.Tasks.Task<int> MultiplierAsync(int a, int b);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public WebAppService.ServiceReference2.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(WebAppService.ServiceReference2.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebAppService.ServiceReference2.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(WebAppService.ServiceReference2.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MyWebServiceSoapChannel : WebAppService.ServiceReference2.MyWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyWebServiceSoapClient : System.ServiceModel.ClientBase<WebAppService.ServiceReference2.MyWebServiceSoap>, WebAppService.ServiceReference2.MyWebServiceSoap {
        
        public MyWebServiceSoapClient() {
        }
        
        public MyWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MyWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebAppService.ServiceReference2.HelloWorldResponse WebAppService.ServiceReference2.MyWebServiceSoap.HelloWorld(WebAppService.ServiceReference2.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            WebAppService.ServiceReference2.HelloWorldRequest inValue = new WebAppService.ServiceReference2.HelloWorldRequest();
            inValue.Body = new WebAppService.ServiceReference2.HelloWorldRequestBody();
            WebAppService.ServiceReference2.HelloWorldResponse retVal = ((WebAppService.ServiceReference2.MyWebServiceSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebAppService.ServiceReference2.HelloWorldResponse> WebAppService.ServiceReference2.MyWebServiceSoap.HelloWorldAsync(WebAppService.ServiceReference2.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebAppService.ServiceReference2.HelloWorldResponse> HelloWorldAsync() {
            WebAppService.ServiceReference2.HelloWorldRequest inValue = new WebAppService.ServiceReference2.HelloWorldRequest();
            inValue.Body = new WebAppService.ServiceReference2.HelloWorldRequestBody();
            return ((WebAppService.ServiceReference2.MyWebServiceSoap)(this)).HelloWorldAsync(inValue);
        }
        
        public int Multiplier(int a, int b) {
            return base.Channel.Multiplier(a, b);
        }
        
        public System.Threading.Tasks.Task<int> MultiplierAsync(int a, int b) {
            return base.Channel.MultiplierAsync(a, b);
        }
    }
}