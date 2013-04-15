using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Nancy.Hosting.Wcf;
using NancyTestDrive;

namespace NancyWcfApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string bindToAddress = "http://localhost:1234/nancy/";

            var t = typeof (HelloModule); // force reference to other project where Modules are defined

            var host = new WebServiceHost(new NancyWcfGenericService(), new Uri(bindToAddress));
            host.AddServiceEndpoint(typeof (NancyWcfGenericService), new WebHttpBinding(), "");
            
            host.Open();

            Console.WriteLine(string.Format("Listening at adress {0} ... press a key to stop", bindToAddress));
            Console.Read();

            host.Close();


        }

        private static Type ForceReferenceToAssemblyWithModules = typeof (HelloModule);
    }
}
