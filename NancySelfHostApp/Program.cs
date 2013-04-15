using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NancyTestDrive;

namespace NancySelfHostApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string bindToAddress = "http://localhost:1234";

            var nancyHost = new Nancy.Hosting.Self.NancyHost(new Uri(bindToAddress));
            nancyHost.Start();

            Console.WriteLine(string.Format("Listening at adress {0} ... press a key to stop", bindToAddress));
            Console.ReadLine();
            nancyHost.Stop();
        }




        // force reference to other project where Modules are defined
        private static Type ForceReferenceToAssemblyWithModules = typeof(HelloModule);
    }
}
