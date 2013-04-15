using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Diagnostics;
using Nancy.TinyIoc;
using WorldDomination.Web.Authentication;
//using WorldDomination.Web.Authentication.Facebook;
using WorldDomination.Web.Authentication.Google;
//using WorldDomination.Web.Authentication.Twitter;

namespace NancyTestDrive
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        //private const string TwitterConsumerKey = "*key*";
        //private const string TwitterConsumerSecret = "*secret*";
        //private const string FacebookAppId = "*key*";
        //private const string FacebookAppSecret = "*secret*";
        private const string GoogleConsumerKey = "972865349389.apps.googleusercontent.com";
        private const string GoogleConsumerSecret = "v5G3H9xjigFfUD1uQ_2BP2r5";

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            //var twitterProvider = new TwitterProvider(TwitterConsumerKey, TwitterConsumerSecret);
            //var facebookProvider = new FacebookProvider(FacebookAppId, FacebookAppSecret);
            var googleProvider = new GoogleProvider(GoogleConsumerKey, GoogleConsumerSecret);

            var authenticationService = new AuthenticationService();

            //authenticationService.AddProvider(twitterProvider);
            //authenticationService.AddProvider(facebookProvider);
            authenticationService.AddProvider(googleProvider);

            container.Register<IAuthenticationService>(authenticationService);
        }   

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            // uncomment this to enable Request Trace
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