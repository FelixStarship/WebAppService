using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace HelloClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HelloProxy proxy = new HelloProxy())
            {
                Console.WriteLine(proxy.Say("郑少秋"));
                Console.ReadLine();
            }
        }
    }
    public interface IService
    {   
       [OperationContract]
        string Say(string name);
    }
    class HelloProxy : ClientBase<HelloService.IHelloService>, IService
    {
        public static readonly Binding HelloBinding = new NetNamedPipeBinding();
        public static readonly EndpointAddress HelloAddress = new EndpointAddress(new Uri("net.pipe://localhost/Hello"));
        public HelloProxy() : base(HelloBinding, HelloAddress)
        {

        }

        public string Say(string name)
        {
            return Channel.SayHello(name);
        }
    }
}
