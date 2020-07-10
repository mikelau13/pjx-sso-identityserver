# pjx-sso-identityserver

Single Sign On using [IdentityServer4](https://identityserver4.readthedocs.io/)

### To Open the Project

Open Project with file `IdentityServer.csproj` inside [Visual Studio 2019](https://visualstudio.microsoft.com/vs/older-downloads/)

### To Launch

```bash
dotnet run
```

Or click `Start Debugging` inside Visual Studio.

After server started running, you can navigate the discovery document - https://localhost:5001/.well-known/openid-configuration

The default OpenID Connect protocol MVC UI have been set up, you can navigate to the login page - https://localhost:5001/Account/Login

To start, default users are being hardcoded in (TestUsers.cs)[~/Quickstart/TestUsers.cs]



# TODO: 

Add OpenID Connect client and OAuth client to consume this SSO server.

Visit [Google Console](https://console.developers.google.com/), create a new project, enable the `Google+ API`, then `Create credentials`, `configure OAuth consent screen`, and configure the callback address, finally uncomment codes in Startup.cs

Store the client and secret into key vault.
