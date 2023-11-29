using Engine.Objects.Implementations;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Runners.TestingProject
{
    public class TestingProjectRunner
    {
        private List<Task> Suites = null;
        public List<DotSIDEImplementation> TestingProjects { get; init; }
        public string BaseTargetUri { get; init; }
        public uint ExecutionSpeed { get; init; }
        internal IWebDriver Driver { get; init; }
        public void Run() 
        {
            foreach (DotSIDEImplementation sf in TestingProjects) // maybe run SideFile
            {
                sf.Run(Driver);
            }
            Driver.Close();
        }
        private CancellationTokenSource cancellationTokenSource;
        public List<Task> RunAsync()
        {
            Suites = new List<Task>();
            cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            foreach (DotSIDEImplementation sf in TestingProjects) // maybe run SideFile
            {
                Suites.Add(
                    Task.Run(() => 
                        {
                            if (cancellationToken.IsCancellationRequested)
                            {
                                sf.Dispose();
                                cancellationToken.ThrowIfCancellationRequested();
                            }
                            else 
                            {
                                cancellationToken.ThrowIfCancellationRequested();
                                sf.Run(Driver);
                            }
                        },
                        cancellationToken
                    )
                );
            }
            Driver.Close();
            return Suites;
        }
        public void RunCancell() 
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
        }
    }
}
