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

## To run the app

First of all, need configure the `hosts` file to map `127.0.0.1` with `pjx-sso-identityserver`:
```
127.0.0.1   pjx-sso-identityserver
```

Usually you can edit the `hosts` file with `sudo nano /etc/hosts` on Linux, or the file is located at `C:\Windows\System32\Drivers\etc\hosts` for Windows.

To start the docker container:

```bash
docker-compose up
```

Or, run this command line in terminal:

```bash
dotnet run
```

Or open the project in Visual Studio 2019, click `Start Debugging`.

Since the app is currently using a self-signed SSL certificate, most web browsers will consider this site "unsafe" and would block you from accessing them. To continuous testing this app on localhost, you will need to configure your web browsers to allow the access.

For example, this is how to do this in [Chrome](https://support.google.com/chrome/answer/99020?co=GENIE.Platform%3DDesktop&hl=en).

Then you can navigate to the discovery document - https://pjx-sso-identityserver:5002/.well-known/openid-configuration

The default OpenID Connect protocol MVC UI have been set up, you can navigate to the login page - https://pjx-sso-identityserver:5002/Account/Login

To register a new user, you will need to visit the `/register` page in the [pjx-web-react](https://github.com/mikelau13/pjx-web-react) web client.


# TODO: 

Visit [Google Console](https://console.developers.google.com/), create a new project, enable the `Google+ API`, then `Create credentials`, `configure OAuth consent screen`, and configure the callback address, finally uncomment codes in Startup.cs

Store the client and secret into key vault.

Set up `hosts` file for `pjx-sso-identityyserver`, now there is a known issue that the identity server have a different domain for the web client and for the web api, this is causing issue when setting up SSL.
