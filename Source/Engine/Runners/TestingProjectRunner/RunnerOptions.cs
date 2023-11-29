using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Runners.TestingProject
{
    public class RunnerOptions
    {
        public TestOrigins TestOriginType { get; set; }
        public AbsTestOrigin TestOrigin { get; set; }
        public Uri BaseTargetUrl { get; set; }
        public uint ExecutionSpeed { get; set; }
        public IWebDriverOptions WebDriverOptions { get; set; }
    }
}
