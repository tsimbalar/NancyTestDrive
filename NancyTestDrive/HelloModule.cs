using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

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
                return "Hello " + parameters.name;
            };

            // would capture routes like /products/1034 sent as a DELETE request
            Delete[@"/products/(?<id>[\d]{1,7})"] = parameters =>
            {
                return 200;
            };

            // would capture routes like /users/192/add/moderator sent as a POST request
            Post["/users/{id}/add/{category}"] = parameters =>
            {
                return HttpStatusCode.OK;
            };
        }
    }
}