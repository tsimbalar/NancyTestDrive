using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using NancyTestDrive.Model;

namespace NancyTestDrive
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get["/"] = parameters => View["login", new IndexViewModel()];

            // would capture routes like /hello/nancy sent as a GET request
            Get["/hello/{name}"] = parameters =>
                {
                    // bind from querystring, form, body etc
                    var model = this.Bind<GreetingModel>();
                    return View[model];
                };
        }
    }

    public class GreetingModel
    {
        public string Name { get; set; }
    }
}