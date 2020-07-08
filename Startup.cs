// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // uncomment, if you want to add an MVC-based UI
            services.AddControllersWithViews();

            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(Config.IdentityResources) // Register the identity resources of OpenID Connecct
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddTestUsers(IdentityServerHost.Quickstart.UI.TestUsers.Users) // sample UI also comes with an in-memory “user database”; navigate to the TestUsers class to see 2 users alice and bob
                .AddInMemoryClients(Config.Clients);

            builder.AddDeveloperSigningCredential();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            // uncomment if you want to add MVC
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            // uncomment, if you want to add MVC-based
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}