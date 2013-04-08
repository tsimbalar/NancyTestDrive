using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace NancyTestDrive
{
    public class ResourceModule : NancyModule
    {
        public ResourceModule()
            : base("/products")
        {
            // would capture routes to /products/list sent as a GET request
            Get["/list"] = parameters =>
            {
                return "The list of products";
            };
        }
    }
}