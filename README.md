# pjx-sso-identityserver

Single Sign On using [IdentityServer4](https://identityserver4.readthedocs.io/)

### To Open the Project

Use Visual Studio 2019, open Project with file `IdentityServer.csproj`

### To Launch

```bash
dotnet run
```

Or Start Debugging inside Visual Studio.

After server started run, you can navigate the discovery document - https://localhost:5001/.well-known/openid-configuration

The default OpenID Connect protocol have been set up, you can navigate to the login page - https://localhost:5001/Account/Login

TODO: Add OpenID Connect client and Oauth client to consume this SSO server.
