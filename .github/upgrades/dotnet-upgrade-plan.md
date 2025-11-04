# .NET 9 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that a .NET 9 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 9 upgrade.
3. Upgrade SummitSample.AppHost.csproj
4. Upgrade SummitSample.ServiceDefaults.csproj

## Settings

This section contains settings and data used by execution steps.

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                              | Current Version | New Version | Description                         |
|:------------------------------------------|:---------------:|:-----------:|:------------------------------------|
| Aspire.Hosting.AppHost                    |   9.4.2         |  9.5.2      | Update to latest Aspire version     |
| Aspire.Hosting.PostgreSQL                 |   9.4.2         |  9.5.2      | Update to latest Aspire version     |
| Aspire.Hosting.Redis                      |   9.4.2         |  9.5.2      | Update to latest Aspire version     |
| Microsoft.Extensions.ServiceDiscovery     |   9.4.2         |  9.5.2      | Update to latest Aspire version     |

### Project upgrade details

This section contains details about each project upgrade and modifications that need to be done in the project.

#### SummitSample.AppHost.csproj modifications

NuGet packages changes:
  - Aspire.Hosting.AppHost should be updated from `9.4.2` to `9.5.2` (*update to latest Aspire version*)
  - Aspire.Hosting.PostgreSQL should be updated from `9.4.2` to `9.5.2` (*update to latest Aspire version*)
  - Aspire.Hosting.Redis should be updated from `9.4.2` to `9.5.2` (*update to latest Aspire version*)

#### SummitSample.ServiceDefaults.csproj modifications

NuGet packages changes:
  - Microsoft.Extensions.ServiceDiscovery should be updated from `9.4.2` to `9.5.2` (*update to latest Aspire version*)