using System;
using System.IO;
using System.Reflection;
using das.Extensions.Logger;
using das.Extensions.Logger.Abstractions;

namespace XML4PFR.Core
{
    public static class App
    {
        public static string Name = Assembly.GetExecutingAssembly().GetName().Name;
        public static string Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static class Paths
        {
            public static string ROOT = AppDomain.CurrentDomain.BaseDirectory;
            public static string XML = Directory.CreateDirectory(Path.Combine(ROOT, "XML.RESULT")).FullName;
        }

        public static Config Config = Config.Load(Path.Combine(Paths.ROOT, $"{Name}.cfg"));
        public static ILogger Log = LoggerFactory.CreateFactory(Config.LoggerProvider).CreateLogger();
    }
}
