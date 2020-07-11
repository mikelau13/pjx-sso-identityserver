# pjx-sso-identityserver

Single Sign On using [IdentityServer4](https://identityserver4.readthedocs.io/)

## Prerequisites

The project is built with .NET Core SDK 3.1, here is how to [check if .NET Core is already installed](https://docs.microsoft.com/en-us/dotnet/core/install/how-to-detect-installed-versions?pivots=os-windows) or not.

See how to install [.NET Core SDK and Runtime](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu) 3.1 in Ubuntu.


## To Open the Project

Use Visual Studio 2019, open Project with file `IdentityServer.csproj`.

Or open folder in Visual Studio Code, install [extensions from marketplace](https://code.visualstudio.com/docs/languages/csharp).

## To Launch

Run this command line in terminal:

```bash
dotnet run
```

Or Start Debugging inside Visual Studio.

After server started running, you can navigate to the discovery document - https://localhost:5001/.well-known/openid-configuration

The default OpenID Connect protocol have been set up, you can navigate to the login page - https://localhost:5001/Account/Login

TODO: Add OpenID Connect client and Oauth client to consume this SSO server.
