using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Testing;
using Nancy.Testing.Fakes;

namespace NancyTestDrive.Tests.TesUtils
{
    public class TestBootstrapper : DefaultNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider
        {
            // in test context, the views are not around ... help Nancy find the views !
            get { return new StaticRootPathProvider(@"D:\Personnel\Dev\NancyTestDrive\NancyTestDrive\"); }
        }
    }
}
