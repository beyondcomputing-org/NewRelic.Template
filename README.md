# Org.BeyondComputing.NewRelic.Template
New Relic plugin Template

# Using Template
1. Change Solution Name
	Right click rename
2. Change Project Name
	Right click rename
3. Change Default Namespace for project
	Right click -> properties -> Default Namespace
4. Change Namespace
	Change namespace of Program.cs, PluginAgent.cs, PluginAgentFactory.cs
5. Generate new GUID for AssemblyInfo.cs file.
	Visual Studio -> Tools -> Create GUID -> #5 -> Replace "assembly: Guid" with new GUID.
6. Change New Relic GUID
	Update GUID in PluginAgent.CS
7. Update README.md file
	Update this file!!

# Requirements
1. .Net 4.5

# Known Issues

# Configuration

# Installation
1. Download release and unzip on machine to handle monitoring.
2. Edit Config Files
    rename newrelic.template.json to newrelic.json
    Rename plugin.template.json to plugin.json
    Update settings in both config files for your environment
3. Run plugin.exe from Command line

Use NPI to install the plugin to register as a service

1. Run Command as admin: npi install org.beyondcomputing.newrelic.template
2. Follow on screen prompts
