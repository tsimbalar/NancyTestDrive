using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Diagnostics;

namespace NancyTestDrive
{
    public class ThibaudDiagnosticProvider : IDiagnosticsProvider
    {
        public string Name { get { return "Thibaud's diags"; } }
        public string Description { get { return @"It does stuff ..."; } }
        public object DiagnosticObject { get { return new ThibaudDiagnostic(); } }
    }

    public class ThibaudDiagnostic
    {
        public string AddNumbers(int number1, int number2)
        {
            return String.Format("{0} + {1} = {2}", number1, number2, number1 + number2);
        }

        // default convention : look for a property with NameOfMethod + Description ....
        // or use a Nancy.Diagnostics.DescriptionAttribute on the method ...
        public string AddNumbersDescription{get { return "Adds 2 numbers and displays the addition ..."; }}

        // default convention : look for a property with NameOfMethod + Template ....
        // or use a Nancy.Diagnostics.TemplateAttribute on the method ...
        public string AddNumbersTemplate { get { return "<h1>Addition result</h1><p style=\"text-decoration:underline; color:red;\">{{model.Result}}</p>"; } }

        [Description("Shows a list of \"count\" Foos ...")]
        public List<Foo> ShowFoos(int count = 5)
        {
            var result = new List<Foo>();
            for (int i = 0; i < count; i++)
            {
                var f = new Foo(i);
                result.Add(f);
            }

            return result;
        }
    }

    public class Foo
    {
        private readonly int _id;
        private readonly string _name;
        private readonly List<Bar> _bars;

        public Foo(int id)
        {
            _id = id;
            _name = "I am foo " + id;
            _bars = new List<Bar>();
            _bars.AddRange(Enumerable.Range(0, id).Select(index => new Bar(index)));
        }

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public List<Bar> Bars
        {
            get { return _bars; }
        }
    }

    public class Bar
    {
        private readonly string _name;
        private readonly int _age;

        public Bar(int index)
        {
            _age = index;
            _name = "I am Bar #" + index;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Age { get { return _age; } }
    }
}