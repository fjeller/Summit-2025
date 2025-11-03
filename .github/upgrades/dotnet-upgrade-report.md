# .NET Aspire 9.5.2 Upgrade Report

## NuGet Packages

| Package Name                              | Old Version | New Version | Commit ID                                 |
|:------------------------------------------|:-----------:|:-----------:|-------------------------------------------|
| Aspire.Hosting.AppHost                    |   9.4.2     |  9.5.2      | 52fa5b40                                  |
| Aspire.Hosting.PostgreSQL                 |   9.4.2     |  9.5.2      | 52fa5b40                                  |
| Aspire.Hosting.Redis                      |   9.4.2     |  9.5.2      | 52fa5b40                                  |
| Microsoft.Extensions.ServiceDiscovery     |   9.4.2     |  9.5.2      | 62252537                                  |

## All commits

| Commit ID              | Description                                |
|:-----------------------|:-------------------------------------------|
| fdd8006b               | Commit upgrade plan                        |
| 52fa5b40               | Update Aspire packages to version 9.5.2   |
| 62252537               | Update ServiceDiscovery package version    |

## Project feature upgrades

### SummitSample.AppHost.csproj

Here is what changed for the project during upgrade:

- Updated all Aspire.Hosting package references from version 9.4.2 to 9.5.2. This includes:
  - Aspire.Hosting.AppHost
  - Aspire.Hosting.PostgreSQL  
  - Aspire.Hosting.Redis

### SummitSample.ServiceDefaults.csproj

Here is what changed for the project during upgrade:

- Updated Microsoft.Extensions.ServiceDiscovery package from version 9.4.2 to 9.5.2 to incorporate the latest bug fixes and improvements.

## Next steps

The upgrade to Aspire 9.5.2 is now complete. Your application should continue to work as before with the latest Aspire improvements and bug fixes. You may want to:

- Test your application to ensure everything works correctly with the new package versions
- Review the Aspire 9.5.2 release notes for any new features or changes that might benefit your application
- Consider running your test suite to validate functionality