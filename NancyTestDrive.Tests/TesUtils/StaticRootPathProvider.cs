using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace NancyTestDrive.Tests.TesUtils
{
    // from http://www.jefclaes.be/2012/06/making-my-first-nancyfx-test-pass.html
    internal class StaticRootPathProvider : IRootPathProvider
    {
        private readonly string _rootPath;

        public StaticRootPathProvider(string rootPath)
        {
            if (rootPath == null) throw new ArgumentNullException("rootPath");
            _rootPath = rootPath;
        }

        public string GetRootPath()
        {
            // mega ugly !!
            return _rootPath;
        }
    }
}
