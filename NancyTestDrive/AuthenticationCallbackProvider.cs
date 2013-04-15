using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Authentication.WorldDomination;

namespace NancyTestDrive
{
    public class AuthenticationCallbackProvider : IAuthenticationCallbackProvider
    {
        public dynamic Process(NancyModule nancyModule, AuthenticateCallbackData model)
        {
            return nancyModule.Negotiate.WithView("AuthenticateCallback").WithModel(model);
        }
    }
}