using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyTestDrive.Tests
{
    public static class HardReferenceToTestedAssemblies
    {
        private static Type whatever = typeof (NancyTestDrive.HelloModule);
    }
}
