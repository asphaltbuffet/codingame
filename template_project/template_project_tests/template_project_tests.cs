using System;
using System.IO;
using Xunit;

namespace template_project_tests
{
    public class TemplateProjectTests
    {
        public Game g;

        public TemplateProjectTests()
        {
            Console.SetIn(new StreamReader("../../assets/testing.txt"));

            g = new Game();

            Assert.NotNull(g);
        }

        [Fact]
        public void Load_Initialization_Input()
        {
            g.Initialize();

            // TODO: Test your stuff here.
        }
    }
}
