using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy;
using Nancy.Testing;
using NancyTestDrive.Tests.TesUtils;

namespace NancyTestDrive.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GET_hello_with_name_must_return_html_with_name()
        {
            // Arrange		
            var bootstrapper = new TestBootstrapper();
            var browser = new Browser(bootstrapper);

            var expectedName = "Johnny";

            // Act
            var actual = browser.Get("/hello/" + expectedName, with =>
                {
                    with.HttpRequest();
                });

            // Assert	
            Assert.AreEqual(HttpStatusCode.OK, actual.StatusCode, "StatusCode");
            actual.Body["#userName"]
                .ShouldExistOnce()
                .And.ShouldBeOfClass("userInfo")
                .And.ShouldContain(expectedName, StringComparison.CurrentCultureIgnoreCase)
                ;
        }
    }
}
