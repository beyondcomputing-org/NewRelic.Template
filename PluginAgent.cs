using System;
using System.Collections.Generic;
using System.Reflection;
using NewRelic.Platform.Sdk;

namespace Org.BeyondComputing.NewRelic.Template
{
    class PluginAgent : Agent
    {
        // Name of Agent
        private string name;

        /// <summary>
        /// Constructor for Agent Class
        /// Accepts name and other parameters from plugin.json file
        /// </summary>
        /// <param name="name"></param>
        public PluginAgent(string name)
        {
            this.name = name;
        }

        #region "NewRelic Methods"
        /// <summary>
        /// Provides the GUID which New Relic uses to distiguish plugins from one another
        /// Must be unique per plugin
        /// </summary>
        public override string Guid
        {
            get
            {
                return "org.beyondcomputing.newrelic.template";
            }
        }

        /// <summary>
        /// Provides the version information to New Relic.
        /// Uses the 
        /// </summary>
        public override string Version
        {
            get
            {
                return typeof(PluginAgent).Assembly.GetName().Version.ToString();
            }
        }

        /// <summary>
        /// Returns a human-readable string to differentiate different hosts/entities in the New Relic UI
        /// </summary>
        public override string GetAgentName()
        {
            return this.name;
        }

        /// <summary>
        /// This is where logic for fetching and reporting metrics should exist.  
        /// Call off to a REST head, SQL DB, virtually anything you can programmatically 
        /// get metrics from and then call ReportMetric.
        /// </summary>
        public override void PollCycle()
        {
            Console.WriteLine($"Poll Cycle not implemented for {this.name}");
            Console.WriteLine($"Sending Default Plugin Metrics for {this.name}");

            // Uptime Metrics for Plugin
            TimeSpan Uptime = DateTime.Now - System.Diagnostics.Process.GetCurrentProcess().StartTime;
            Console.WriteLine($"Plugin Uptime in seconds: {Uptime.Seconds}");

            // Send Metrics to New Relic
            ReportMetric("plugin/uptime", "seconds", Uptime.Seconds);        
        }

        #endregion
    }
}
