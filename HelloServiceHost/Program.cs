using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace HelloServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyHelloHost host = new MyHelloHost())
            {
                host.Open();
                Console.ReadLine();
            }
        }
    }
    
    public class MyHelloHost : IDisposable
    {
        private ServiceHost _myHelloHost;
        public const string BaseAddress = "net.pipe://localhost";
        public const string HelloServiceAddress = "Hello";
        public static readonly Type ServiceType = typeof(HelloService.HelloService);
        public static readonly Type ContractType = typeof(HelloService.IHelloService);
        public static readonly Binding HelloBinding = new NetNamedPipeBinding();

        public MyHelloHost()
        {
            CreateHelloServiceHost();
        }

        protected void CreateHelloServiceHost()
        {
            _myHelloHost = new ServiceHost(ServiceType, new Uri[] { new Uri(BaseAddress) });
            _myHelloHost.AddServiceEndpoint(ContractType, HelloBinding, HelloServiceAddress);

        }
        public void Open()
        {
            Console.WriteLine("开始启动服务。。。。。");
            _myHelloHost.Open();
            Console.WriteLine("服务已经启动");
        }

        public void Dispose()
        {
            if (_myHelloHost != null)
                (_myHelloHost as IDisposable).Dispose();
        }
    }
}

