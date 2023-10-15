using DB_WordCounter.Classes;
using DB_WordCounter.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.CompilerServices;

namespace DB_WordCounter
{
    internal class Program
    {

        static void Main()
        {
            //Setup DI
            var builder = new ConfigurationBuilder();
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<ITextAnalyzer, WordAnalyzer>();
                    services.AddTransient<ITextExcluder, WordExcluder>();
                    services.AddTransient<ITextSorter, WordSorter>();
                    services.AddTransient<ITextInserter, WordInserter>();
                    services.AddTransient<IEntrypoint, Entrypoint>();
                })
                .Build();
            var service = ActivatorUtilities.CreateInstance<Entrypoint>(host.Services);
            service.StartApplication().Wait();
        }
    }
}