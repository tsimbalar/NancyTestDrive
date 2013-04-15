using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Diagnostics;
using Nancy.TinyIoc;

namespace NancyTestDrive
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            StaticConfiguration.EnableRequestTracing = true;
        }

        protected override Nancy.Diagnostics.DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get
            {
                return new DiagnosticsConfiguration
                    {
                        Password = "password"
                    };
            }
        }


        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);


            // make /js server files from /_scripts
            conventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory("js", "_scripts", ".js" /* only js extension is allowed */) 
                );
        }


    }
}