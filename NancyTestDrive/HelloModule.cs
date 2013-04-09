using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;

namespace NancyTestDrive
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get["/"] = parameters => "Hello World";

            // would capture routes like /hello/nancy sent as a GET request
            Get["/hello/{name}"] = parameters =>
                {
                    //var model = this.Bind<HelloModel>();
                    // or 
                    //HelloModel model = this.Bind();
                    // or
                    var model = new HelloModel();
                    this.BindTo(model);
                    return "Hello " + model.Name;
                };
        }

    }

    public class HelloModel
    {
        public string Name { get; set; }
    }
}