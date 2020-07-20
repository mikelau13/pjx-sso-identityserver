# pjx-sso-identityserver

Single Sign On using [IdentityServer4](https://identityserver4.readthedocs.io/)

## Prerequisites

The project is built with .NET Core SDK 3.1, here is how to [check if .NET Core is already installed](https://docs.microsoft.com/en-us/dotnet/core/install/how-to-detect-installed-versions?pivots=os-windows) or not.

Open Project with file `IdentityServer.csproj` inside [Visual Studio 2019](https://visualstudio.microsoft.com/vs/older-downloads/)

See how to install [.NET Core SDK and Runtime](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu) 3.1 in Ubuntu.

Uer [DB Browser for SQLite](https://sqlitebrowser.org/) to open the database file `AspIdUsers.db`


## To Open the Project

Use Visual Studio 2019, open Project with file `IdentityServer.csproj`.

Or open folder in Visual Studio Code, install [extensions from marketplace](https://code.visualstudio.com/docs/languages/csharp).

## To Launch

To start the docker container:

```bash
docker-compose up
```

Or, run this command line in terminal:

```bash
dotnet run
```

Or open the project in Visual Studio 2019, click `Start Debugging`.

After server started running, you can navigate to the discovery document - http://localhost:5001/.well-known/openid-configuration

The default OpenID Connect protocol MVC UI have been set up, you can navigate to the login page - http://localhost:5001/Account/Login

To start, default users are being hardcoded in (TestUsers.cs)[~/Quickstart/TestUsers.cs]



# TODO: 

Visit [Google Console](https://console.developers.google.com/), create a new project, enable the `Google+ API`, then `Create credentials`, `configure OAuth consent screen`, and configure the callback address, finally uncomment codes in Startup.cs

Store the client and secret into key vault.
