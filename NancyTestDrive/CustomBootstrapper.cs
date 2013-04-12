using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Conventions;

namespace NancyTestDrive
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);


            // make /js server files from /_scripts
            conventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory("js", "_scripts", "js" /* only js extension is allowed */) 
                );


        }
    }
}