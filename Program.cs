using System;
using System.IO;
using NewRelic.Platform.Sdk;

namespace Org.BeyondComputing.NewRelic.Template
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                // Validate Config Files
                CheckConfigFiles();

                // Start New Relic Plugin
                Runner runner = new Runner();
                runner.Add(new PluginAgentFactory());
                runner.SetupAndRun();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred, unable to continue.\nMessage: {0}", e.Message);
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// Checks for existence of config files when starting up
        /// Helps debug issues.  The default New Relic SDK error isn't helpful
        /// </summary>
        /// <returns></returns>
        private static bool CheckConfigFiles()
        {
            Console.WriteLine("Checking if config Files exist");

            /// Check for newrelic.json file - Holds NewRelic license configuration
            if (File.Exists("config/newrelic.json"))
            {
                Console.WriteLine("newrelic.json file exists");
            }
            else
            {
                throw new FileNotFoundException("newrelic.json file not found!");
            }

            /// Check for plugin.json file - Holds plugin settings
            if (File.Exists("config/plugin.json"))
            {
                Console.WriteLine("plugin.json file exists");
            }
            else
            {
                throw new FileNotFoundException("plugin.json file not found!");
            }

            return true;
        }
    }
}
